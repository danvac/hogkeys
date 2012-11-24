if file then
	file:write("---OutputTables.lua: LOADED----","\n")
	file:flush()
end


cockpitIndicators = {
[10001] = {0,191}, -- Canopy light
[10002] = {0,665}  -- TakeOff Trim Light
}

test = {
[10003] = {20,192}
}

outputTables = {cockpitIndicators}