
dofile ("./Config/Export/HogKeys/OutputTables.lua")  
if file then
	file:write("---Output.lua: LOADED----","\n")
	file:flush()
end
-- Support functions to parse and generate suitable commands to the SIOC server.
-- Process simple On/Off indicators
function ProcessOutputs(outputTables)
	if file then
	file:write("---Output.lua: ProcessOutputs---->","\n")
	file:flush()
	end
    local indicatorTable, deviceArg ,outputIndex, outputValue, panel, panelId
    local outputMessage = ""
    
    for i , indicatorTable in pairs(outputTables) 
    do     
        for outputIndex ,deviceArg in pairs(indicatorTable) 
        do 
            -- Check if the panelID changes between indicators 
            if panelId ~= deviceArg[1] then 
                panelId = deviceArg[1]
                -- Get the device
                panel = GetDevice(deviceArg[1])
                --Check to see that the device is valid otherwise we return an emty string
                if type(panel) ~= "table" then
				-- should put error in log here
                    return ""
                end
                -- Update the panel
                --panel:update_arguments()
            end
             
            outputValue = panel:get_argument_value(deviceArg[2])
			outputMessage = outputMessage..outputIndex..":"..outputValue..","
            
        end
    end
	if file then
	file:write("output message:"..outputMessage)
	file:write("---Output.lua: ProcessOutputs<----","\n")
	file:flush()
	end
    return outputMessage
end


-- Generate the SIOC string to reset (turn off) all indicator lamsp
function ResetIndicators(outputTables)
    local indicatorTable, deviceArg ,outputIndex 
    local outputMessage = ""
    
    for i , indicatorTable in pairs(outputTables) 
    do     
        for outputIndex ,deviceArg in pairs(indicatorTable) 
        do 
            outputMessage = outputMessage..outputIndex..":OFF,"
        end            
    end
	if file then
	file:write("output message:"..outputMessage)
	file:write("---Output.lua: ResetIndicators<----","\n")
	file:flush()
	end
    return outputMessage
end

-- Simple round function
function round(num, idp)
  local mult = 10^(idp or 0)
  return math.floor(num * mult + 0.5) / mult
end




function Servo(pPos, pServoTable)
    if pPos <= pServoTable[1][1] then
        return pServoTable[1][2]
    elseif pPos >= pServoTable[#pServoTable][1] then
        return pServoTable[#pServoTable][2]
    else
        for i,j in pairs(pServoTable) do
            if (pPos <= j[1]) then
                return (((j[2]-pServoTable[i-1][2])/(j[1]-pServoTable[i-1][1]))*(pPos-pServoTable[i-1][1])) + pServoTable[i-1][2]
            end
        end
    end
end


-- Device/switch specific functions
 

-- For a simple switch/pushbutton sends 0 (for pValue = 0) and  pOnValue (for pValue = 1)
-- to pDevice (ex 12 for WEAP-Interface). pNumber is the device_commands.Button_?? value from
-- clickabledata.lua, pOnValue is from the arg_lim = {{0.0, 1.0} part from clickabledata.lua. 
-- Set pInvert ~= nil to invert. 
function TwoPositionSwitch(pValue, pDevice, pNumber, pOnValue, pInvert)
    if pInvert then
        if pValue == 1 then
           pValue = 0
        else
           pValue = 1
        end
    end
 
    GetDevice(pDevice):performClickableAction(pNumber + 3000, pValue * pOnValue)
end


--For a rotary/rotary switch, sends (pValue - 1/10) to pDevice (ex 12 for WEAP-Interface)
-- Set your SIOC parameter to 1 for position 1, 2 for position 2.....etc.  
function SimpleRotary(pValue, pDevice, pNumber)
    GetDevice(pDevice):performClickableAction(pNumber + 3000,(pValue - 1)/10)
end

