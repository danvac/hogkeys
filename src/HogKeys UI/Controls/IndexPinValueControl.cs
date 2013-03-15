using System.Windows.Forms;

namespace net.willshouse.HogKeys.UI.controls
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
