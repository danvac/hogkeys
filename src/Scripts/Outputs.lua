


-- Support functions to parse and generate suitable commands to the SIOC server.
-- Process simple On/Off indicators
function ProcessIndicators(pIndicatorTables)
    local lIndicatorTable, lDevice_Arg ,lSIOC_Var, lArgumentValue, lPanel, lPanelId
    local lSIOC_SendString = ""
    
    for i , lIndicatorTable in pairs(pIndicatorTables) 
    do     
        for lSIOC_Var ,lDevice_Arg in pairs(lIndicatorTable) 
        do 
            -- Check if the panelID changes between indicators 
            if lPanelId ~= lDevice_Arg[1] then 
                lPanelId = lDevice_Arg[1]
                -- Get the device
                lPanel = GetDevice(lDevice_Arg[1])
                --Check to see that the device is valid otherwise we return an emty string
                if type(lPanel) ~= "table" then
                    return ""
                end
                -- Update the panel
                lPanel:update_arguments()
            end
             
            lArgumentValue = lPanel:get_argument_value(lDevice_Arg[2])
            -- For some reason the get_argument_value function call above returns 0.1000001256, 0.20000012313 
            -- or similar so we need round this value to 0.1, 0.2 etc
            lArgumentValue = round(lArgumentValue, 1)
    
            -- 0 or 0.2 means that the indicator should be off => the SIOC param should be 0
            -- For any other value the indicator should be on => the SIOC param should be 1
            if ((lArgumentValue == 0) or (lArgumentValue == 0.2)) then
                lSIOC_SendString = lSIOC_SendString..lSIOC_Var.."=0:"
            else
                lSIOC_SendString = lSIOC_SendString..lSIOC_Var.."=1:"
            end            
        end
    end
    return lSIOC_SendString
end


-- Generate the SIOC string to reset (turn off) all indicator lamsp
function ResetIndicators(pIndicatorTables)
    local lIndicatorTable, lDevice_Arg ,lSIOC_Var 
    local lSIOC_SendString = ""
    
    for i , lIndicatorTable in pairs(pIndicatorTables) 
    do     
        for lSIOC_Var ,lDevice_Arg in pairs(lIndicatorTable) 
        do 
            lSIOC_SendString = lSIOC_SendString..lSIOC_Var.."=0:"
        end            
    end
    return lSIOC_SendString
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

