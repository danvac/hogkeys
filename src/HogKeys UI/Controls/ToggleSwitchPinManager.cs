using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using net.willshouse.HogKeys.IO;

namespace net.willshouse.HogKeys.UI.controls
{
    public partial class ToggleSwitchPinManager : UserControl
    {
        private ToggleSwitch currentSwitch;

        public ToggleSwitchPinManager()
        {
            InitializeComponent();
        }

        public ToggleSwitch Switch
        {
            get { return currentSwitch; }

            set
            {
                currentSwitch = value;
                if ((currentSwitch != null) & (currentSwitch.Values.Count > 1) & currentSwitch.Pins.Count > 0)
                {
                    offTextBox.Text = currentSwitch.Values[0];
                    onTextBox.Text = currentSwitch.Values[1];
                    pinNumericUpDown.Value = currentSwitch.Pins[0];
                }
            }
        }

        public void SaveHandler(object sender, EventArgs e)
        {
            currentSwitch.Pins.Clear();
            currentSwitch.Pins.Add((int)pinNumericUpDown.Value);
            currentSwitch.Values.Clear();
            currentSwitch.Values.Add(offTextBox.Text);
            currentSwitch.Values.Add(onTextBox.Text);
        }



    }
}
