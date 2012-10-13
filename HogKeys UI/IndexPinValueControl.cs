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
    public partial class IndexPinValueControl : UserControl
    {

        public IndexPinValueControl()
        {
            InitializeComponent();
        }

        public int Index
        {
            set
            {

                indexLabel.Text = value + ":";
            }
        }

        public int PinNumber
        {
            get { return (int)pinNumericUpDown.Value; }

            set
            {
                pinNumericUpDown.Value = value;
            }
        }

        public string PinValue
        {
            get { return valueTextBox.Text; }

            set
            {
                valueTextBox.Text = value;
            }
        }
    }
}
