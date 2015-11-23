# User Guide #

HogKeys is a utility that allows you to map Pokeys inputs/outputs to DCS: A-10 controls utilizing DCS' Lua Import/Export facilities.


# Overview #

There are two components to HogKeys, A C# Gui for configuring the inputs, And a Lua script for DCS to process the data.

## Current Features (as 1.1) ##
  * Currently HogKeys allows you to map inputs and outputs from a single USBPokeys board to DCS clickable items only.

  * All input connections are via a Matrix Input only

  * There are three types of switches modeled, a Toggle Switch, a Binary Switch, and a Multiple-Position Switch.
  * 80 discrete outputs available on PoExtBus only

## Planned Features ##
  * Multiple Pokeys Boards including Ethernet
  * Analog inputs (In Progress)
  * Rotary encoder inputs
  * 7 segment display support (In Progress)
  * PWM output (e.g. dimmers and servos)
  * Concurrent Matrix and Direct Inputs