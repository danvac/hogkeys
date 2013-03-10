
dcsHost = "127.0.0.1"
dcsPort = 9189
hogkeysHost = "127.0.0.1"
hogkeysPort = 9190
NL="\n"


file = io.open(os.getenv("USERPROFILE").."/Saved Games/DCS/Logs/HogKeysExport.log", "w")
if file then
	file:write("---LOG: START----","\n")
	file:flush()
end
dofile (scriptPath.."/HogKeys/Outputs.lua") 

hogkeysPrevExport = {}
hogkeysPrevExport.LuaExportStart = LuaExportStart
hogkeysPrevExport.LuaExportStop = LuaExportStop
hogkeysPrevExport.LuaExportBeforeNextFrame = LuaExportBeforeNextFrame
hogkeysPrevExport.LuaExportAfterNextFrame = LuaExportAfterNextFrame
hogkeysPrevExport.LuaExportActivityNextEvent = LuaExportActivityNextEvent
 
function StrSplit(str, delim, maxNb)
    -- Eliminate bad cases...
    if string.find(str, delim) == nil then
        return { str }
    end
    if maxNb == nil or maxNb < 1 then
        maxNb = 0    -- No limit
    end
    local result = {}
    local pat = "(.-)" .. delim .. "()"
    local nb = 0
    local lastPos
    for part, pos in string.gfind(str, pat) do
        nb = nb + 1
        result[nb] = part
        lastPos = pos
        if nb == maxNb then break end
    end
    -- Handle the last field
    if nb ~= maxNb then
        result[nb + 1] = string.sub(str, lastPos)
    end
    return result
end

function ResetChangeValues()
	logfile:write("Sending all values.", "\n")
	for lArgument, lFormat in pairs(gArguments) do
		gLastData[lArgument] = "99999" 
	end
end

function ProcessInput()
	--file:write("->ProcessInput()","\n")
	--file:flush()
    local lInput = dcsSocket:receive()
    local lCommand, lCommandArgs, lDevice, lArgument, lLastValue
    
    if lInput then
		file:write("Message Received:",lInput,NL)
		file:flush()
        lCommand = string.sub(lInput,1,1)
        
		if lCommand == "R" then
			ResetChangeValues()
		end
	
		if (lCommand == "C") then
			file:write("lCommmand is C",NL)
			lCommandArgs = StrSplit(string.sub(lInput,2),",")
			file:write("device:",lCommandArgs[1]," Button:",lCommandArgs[2], " Value:",lCommandArgs[3],NL)
			lDevice = GetDevice(lCommandArgs[1])
			if type(lDevice) == "table" then
				lDevice:performClickableAction(lCommandArgs[2],lCommandArgs[3])	
			end
		end
		file:flush()
    end
	--file:write("<--ProcessInput()","\n")
	--file:flush()
end

function LuaExportStart()

 	local version = LoGetVersionInfo() --request current version info (as it showed by Windows Explorer fo DCS.exe properties)
    if version and file then
 	    
 		file:write("ProductName: "..version.ProductName..'\n')
 		file:write(string.format("FileVersion: %d.%d.%d.%d\n",
 												version.FileVersion[1],
 												version.FileVersion[2],
 												version.FileVersion[3],
 												version.FileVersion[4]))
 		file:write(string.format("ProductVersion: %d.%d.%d.%d\n",
 												version.ProductVersion[1],
 												version.ProductVersion[2],
 												version.ProductVersion[3],  -- head  revision (Continuously growth)
												version.ProductVersion[4])) -- build number   (Continuously growth)	
		file:flush()
    end
	package.path  = package.path..";.\\LuaSocket\\?.lua"
    package.cpath = package.cpath..";.\\LuaSocket\\?.dll"
   
    socket = require("socket")
    
    dcsSocket = socket.udp()
    dcsSocket:setsockname(dcsHost, dcsPort)
    dcsSocket:settimeout(.01) -- set the timeout for reading the socket 
	hogkeysSocket = socket.udp()
	hogkeysSocket:setpeername(hogkeysHost,hogkeysPort)
	hogkeysPrevExport.LuaExportStart()
end

function LuaExportBeforeNextFrame()
	ProcessInput()

	hogkeysPrevExport.LuaExportBeforeNextFrame()
end

function LuaExportAfterNextFrame()
	hogkeysPrevExport.LuaExportAfterNextFrame()
end

function LuaExportStop()

   if file then
	   file:write("---Shutting Down Outputs---\n")
	   file:flush()
   end

   hogkeysSocket:send(ResetIndicators(outputTables))

   if file then
	  file:write("---LOG: STOP----","\n")
	  file:flush()
	  file:close()
	  file = nil
   end
   dcsSocket:close()
   hogkeysSocket:close()
   hogkeysPrevExport.LuaExportStop()
end

function LuaExportActivityNextEvent(t)
	local tNext = t
    hogkeysSocket:send(ProcessOutputs(outputTables))
	tNext = tNext +.05
	return hogkeysPrevExport.LuaExportActivityNextEvent(t)
end

