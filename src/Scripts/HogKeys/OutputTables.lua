if file then
	file:write("---OutputTables.lua: LOADED----","\n")
	file:flush()
end


cockpitIndicators = {
[10001] = {0,404}, -- Master Caution
[10002] = {0,665},  -- Canopy Unlocked
[10003] = {0,191} -- TakeOff Trim Light
}

outputTables = {cockpitIndicators}