# Introduction #

Add your content here.


## Inputs ##

### Input Matrix ###
An Input Matrix is just like a [keyboard matrix circuit](http://www.dribin.org/dave/keyboard/html/martix-circuit.html). It contains 8 columns (from A-H) and 16 rows (1-16). The Diodes must be installed as shown to prevent Ghosting on the switches. Below is an example diagram.
**V1.1.0** Added a pull up resistor to prevent issues with diode vdrop issues
http://wiki.hogkeys.googlecode.com/hg/images/inputMatrixv1_1.PNG

### Switches ###

Three types of switches are supported. The Toggle Switch, The Binary Switch and The Multi-Position Switch.  All of these switches have the same basic properties.

**Warning in the current version positions are mapped to pins. This nomenclature is incorrect for a matrix. In a matrix you have an index e.g A1,B16 etc.  which are mapped to a numeric index from 0-127. So when you see pin for now think index**

  * Device ID.  This is the device id of the switch in the sim.
  * Button ID.  This is the button id of the switch in the sim. normally you add 3000 to the value listed in the clickableobjects.lua
  * at least two positions.  Depending on the switch type these are mapped differently to pins (indexes).
  * each position will have a value associated to it.

#### Example ####
> Lets setup the Battery Switch on the Electrical control panel.
  1. Launch HogKeys and select File...New...Input...Switch...ToggleSwitch
  1. This will launch the SwitchDetail view
  1. open the clickabledata.lua in the scripts/aircrafts/A-10C/cockpit dir
  1. search for the battery switch.
    * you will see something like:

> elements["PTR-EPP-BATTERY-PWR"] = {class =   {class\_type.TUMB,class\_type.TUMB}, hint  = _("Battery Power"), device = **devices.ELEC\_INTERFACE**, action = {**device\_commands.Button\_6**, device\_commands.Button\_6}, arg = {246,246}, arg\_value = {**-1,1**}, arg\_lim = {{0,1},{0,1}},updatable = true}_

  * I have highlighted the parts of interest.
  1. So your device id can be found by opening up devices.lua and looking for devices.ELECT\_INTERFACE, which in this case is 1
  1. Button ID is located in device\_commands.Button\_6 so its 3006 (remember to add 3000 to the number listed)
  1. the off (position 0) value is located in arg\_value = {-1,1} so its -1
  1. the On (position 1) value is the second number in the arg\_value: 1.
  1. the switch pin (index) is determined by where on the matrix the switch is wired to. Lets assume B4. This is the tricky part. The index is valued from 0-127 starting at A1 and going to B1,C1,D1,E1,F1,G1,H1 then A2,B2,etc all the way up to H16 (index 127) So B4 would be pin (index) 33. This part is a bit convoluted so i will most likely enhance HogKeys to use A1,B2 etc and do the conversion for you.

![http://wiki.hogkeys.googlecode.com/hg/images/ExampleSwitch.png](http://wiki.hogkeys.googlecode.com/hg/images/ExampleSwitch.png)

## Outputs ##

### Discrete Output Matrix ###
A Discrete Output Matrix is a way of enabling up to 80 discrete outputs via the PoExtBus feature.  Currently this is only enabled on pins 35,36,37 and not the PoExtBus connector.

**Ensure you build a circuit that does not exceed the current requirements of the PoKeys device**
http://wiki.hogkeys.googlecode.com/hg/images/PoExtBus.PNG

### Adding an Output ###

http://wiki.hogkeys.googlecode.com/hg/images/outputDetailForm.PNG