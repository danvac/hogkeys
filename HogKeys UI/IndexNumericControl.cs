using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace net.willshouse.HogKeys.UI
{
    public partial class IndexNumericControl : UserControl
    {
        private int pinIndex, pinNumber;
        public IndexNumericControl()
        {
            InitializeComponent();
        }

        public int PinIndex 
        {
            get { return pinIndex; }
            set
            {
                pinIndex = value;
                pinIndexLabel.Text = pinIndex.ToString();
            }
        }

        public int PinNumber 
        {
            get { return pinNumber; }
            set
            {
                pinNumber = value;
                pinNumericUpDown.Value = pinNumber;
            }
        }

        private void pinNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            pinNumber = Convert.ToInt32(pinNumericUpDown.Value);
        }
    }
}
