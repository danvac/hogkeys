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
    public partial class IndexValueControl : UserControl
    {
        private int switchPosition;
        private string switchValue;
        public IndexValueControl()
        {
            InitializeComponent();
        }

        public int SwitchPosition 
        {
            get { return switchPosition; }
            set
            {
                switchPosition = value;
                switchPositionLabel.Text = switchPosition.ToString();
            }
        }

        public string SwitchValue 
        {
            get { return switchValue; }
            set
            {
                switchValue = value;
                SwitchValueTextBox.Text = switchValue;
            }
        }

        private void SwitchValueTextBox_TextChanged(object sender, EventArgs e)
        {
            switchValue = SwitchValueTextBox.Text;
        }
    }
}
