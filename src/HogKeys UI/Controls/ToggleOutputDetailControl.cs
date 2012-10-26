using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.Outputs;

namespace net.willshouse.HogKeys.UI.Controls
{
    public partial class ToggleOutputDetailControl : UserControl
    {
        private ToggleOutput currentOutput;

        public ToggleOutputDetailControl()
        {
            InitializeComponent();
        }

        public ToggleOutput Output
        {
            get { return currentOutput; }

            set
            {
                currentOutput = value;
                if (currentOutput != null)
                {
                    if (currentOutput.Index.Count > 0)
                    {
                        indexNumericUpDown.Value = currentOutput.Index[0];
                    }
                    logicOnMaskedTextBox.Text = String.Format("{0:000.00}",currentOutput.LogicOnValue);
                    
                }
            }
        }

        public void SaveHandler(object sender, EventArgs e)
        {
            currentOutput.Index.Clear();
            currentOutput.Index.Add((int)indexNumericUpDown.Value);
            currentOutput.LogicOnValue = Convert.ToDouble(logicOnMaskedTextBox.Text);
        }
    }
}
