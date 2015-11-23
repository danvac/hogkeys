# Installation #
Installation is pretty straight forward and consists of the following steps:
  * Installing prerequisites
  * Installing Hogkeys-Setup
  * Enabling lua support in DCS
  * copying in the export.lua script

## Requirements ##
  * .Net 4.0
  * PokeysUSB board using a "Keyboard Matrix"
  * Pokeys software Installed


## HogKeys-Setup.exe ##

Double-click the HogKeys-Setup.exe and follow the prompts

## Export.lua ##
  1. Navigate to {Install Dir}\Config\Export directory
  1. Open Config.lua and change EnableExportStript from false to true.
  1. Save and close Config.lua
  1. Make a backup of Export.lua e.g Export.lua.Orig
  1. Copy the contents of the {HogKeys Install}/script directory here.
  1. Open Export.lua and change the following:
    1. host to your ip address or hostname.  Only set this to localhost if you are running HogKeys on the same computer as DCS.
    1. hogKeysHost set this to the hostname or IP of the machine running HogKeys
    1. hogKeysPort default:9090 an unused port on machine running HogKeys
    1. port to an unused port. The default of 9089 is fine
  1. If required verify the port above is opened in your firewall