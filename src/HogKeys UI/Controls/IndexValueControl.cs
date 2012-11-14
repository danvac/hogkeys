using System;
using System.Windows.Forms;

namespace net.willshouse.HogKeys.UI.controls
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
