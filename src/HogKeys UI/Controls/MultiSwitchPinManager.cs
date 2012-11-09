using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.IO.Inputs.Switches;

namespace net.willshouse.HogKeys.UI.controls
{
    public partial class MultiSwitchPinManager : UserControl
    {
        private MultiSwitch currentSwitch;
        private List<IndexPinValueControl> multiControls;
        
        public MultiSwitchPinManager()
        {
            multiControls = new List<IndexPinValueControl>();
            InitializeComponent();
        }

        public MultiSwitch Switch 
        {
            get { return currentSwitch; }

            set
            {
                currentSwitch = value;
                if (currentSwitch != null)
                {
                    LoadPositionsPanel();

                }
            }
        }

        public void SaveHandler(object sender, EventArgs e)
        {
            currentSwitch.Pins.Clear();
            currentSwitch.Values.Clear();
            foreach (IndexPinValueControl pinValue in multiControls)
            {
                currentSwitch.Pins.Add(pinValue.PinNumber);
                currentSwitch.Values.Add(pinValue.PinValue);
            }
        }

        private void LoadPositionsPanel()
        {
            positionsNumericUpDown.Value = currentSwitch.Pins.Count;
            pinLayoutPanel.Controls.Clear();
            multiControls.Clear();
            // need to create a new control with numericupdown and text field 
            //for pin index pin number and value text.  IndexPinValueControl
            for (int i = 0; i < currentSwitch.Pins.Count; i++)
            {
                multiControls.Add(new IndexPinValueControl());
                multiControls[i].Index = i + 1;
                multiControls[i].PinNumber = currentSwitch.Pins[i];
                multiControls[i].PinValue = currentSwitch.Values[i];
                pinLayoutPanel.Controls.Add(multiControls[i]);
            }
        }

        private void positionsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int newCount = (int)positionsNumericUpDown.Value;
            if (newCount > 1)
            {
                int delta = newCount - multiControls.Count;
                if (delta < 0)
                {
                    for (int i = 0; i > delta; i--)
                    {
                        multiControls.RemoveAt(multiControls.Count - 1);
                        pinLayoutPanel.Controls.RemoveAt(pinLayoutPanel.Controls.Count - 1);
                    }
                }
                else
                {
                    for (int i = 0; i < delta; i++)
                    {
                        multiControls.Add(new IndexPinValueControl());
                        int index = multiControls.Count - 1;
                        multiControls[index].Index = multiControls.Count;
                        multiControls[index].PinNumber = 0;
                        multiControls[index].PinValue = String.Empty;
                        pinLayoutPanel.Controls.Add(multiControls[index]);
                    }
                }
            }
            else positionsNumericUpDown.Value = 2;
        }

    }
}
