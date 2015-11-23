# Introduction #

## Pokeys Configuration ##
  1. ollow the Pokeys Documentation to create a 16x8 Matrix. Verify It works in Pokeys by clicking on Peripherals ,selecting switch matrix, and testing your switches.  For more information on the Matrix circuit see [Input Matrix](Concepts#Input_Matrix.md)
  1. Follow the Pokeys Documentation to enable the PoExtBus on pins 35,36,37
## Connecting to your sim ##
Launch HogKeys and click on the settings tab
  1. Set the DCS host to the hostname or ip you configured in Export.lua
  1. Set the DCS port to the port you configured in Export.lua
  1. Set the HogKeys port to the hogKeysPort you configured in Export.lua

### Polling Configuration ###
#### Inputs ####
In the settings tab there is a Polling interval option.
This allows you to set how many times per second you want to poll Pokeys and send any differences to DCS.  The minimum is 1 per second (polls every 1000 ms) and the max is 50 per second (20ms).  The default of 25/sec is fine in most cases.

#### Outputs ####
Outputs are sent to HogKeys every 50ms (20 times/second).  This is set in the Export.lua script

## Loading and Saving your Configuration ##
There are two types of configurations in HogKeys.
The first is the Input Configuration. This holds the configuration settings for each input you have defined.  You can load and save this from the File menu.
The second is the user configuration and contains things like host, port, and polling intervals.  This is loaded by default when you start the program.  To save changes to these settings.  Click the Save button on the settings page.  The revert button will load the currently saved options.