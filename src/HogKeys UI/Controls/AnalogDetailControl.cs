using System;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;

namespace net.willshouse.HogKeys.UI.Controls
{
    public partial class AnalogDetailControl : UserControl
    {
        AnalogInput currentInput;
        TestDriver driver;
        public AnalogDetailControl()
        {
            driver = new TestDriver();
            
            InitializeComponent();
        }

        public AnalogInput Input
        {
            get
            {
                return currentInput;
            }
            set
            {
                currentInput = value;
                if (currentInput != null)
                {
                    try
                    {
                        driver.InitializeConnection(0); // need to use index of pokeys device in future
                    }
                    catch (Exception )
                    {
                        setMinButton.Enabled = false;
                        setMaxButton.Enabled = false;
                    }
                    minRawTextBox.Text = currentInput.CalMin.ToString();
                    maxRawTextBox.Text = currentInput.CalMax.ToString();
                    minValTextBox.Text = currentInput.MinValue.ToString();
                    maxValTextBox.Text = currentInput.MaxValue.ToString();
                    indexNumericUpDown.Value = currentInput.Index;
                }
            }
        }

              

        public void SaveHandler(object sender, EventArgs e)
        {
            currentInput.CalMax = Convert.ToInt32(maxRawTextBox.Text);
            currentInput.CalMin = Convert.ToInt32(minRawTextBox.Text);
            currentInput.MaxValue = Convert.ToDouble(maxValTextBox.Text);
            currentInput.MinValue = Convert.ToDouble(minValTextBox.Text);
            currentInput.Index = (int)indexNumericUpDown.Value;
        }

        private void setMinButton_Click(object sender, EventArgs e)
        {
            
            minRawTextBox.Text = driver.PollAnalogIndex(currentInput.Index).ToString();
        }

        private void setMaxButton_Click(object sender, EventArgs e)
        {
            maxRawTextBox.Text = driver.PollAnalogIndex(currentInput.Index).ToString();
        }


    }
}
