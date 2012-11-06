using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using System.Collections;

namespace net.willshouse.HogKeys.UI.controls
{
    public partial class BinarySwitchPinManager : UserControl
    {
        private BindingList<IndexValueControl> binaryValues;
        private BindingList<IndexNumericControl> binaryPins;
        private BinarySwitch switch1;

        public BinarySwitchPinManager()
        {
            binaryValues = new BindingList<IndexValueControl>();
            binaryPins = new BindingList<IndexNumericControl>();
            InitializeComponent();
        }

        public BinarySwitch Switch
        {
            get { return switch1; }
            set
            {
                switch1 = value;
                if (switch1 != null)
                {
                    PinsNumericUpDown.Value = switch1.Pins.Count;
                    int newCount = (int)Math.Pow(2, Convert.ToDouble(PinsNumericUpDown.Value));
                    valuesLabel.Text = newCount.ToString() + " Positions";
                    LoadPinsPanel();
                    LoadValuesPanel();
                }
            }
        }

        public void SaveHandler(object sender, EventArgs e)
        {
            switch1.Pins.Clear();
            foreach (IndexNumericControl pin in binaryPins)
            {
                switch1.Pins.Add(pin.PinNumber);
            }

            switch1.Values.Clear();
            foreach (IndexValueControl value in binaryValues)
            {
                switch1.Values.Add(value.SwitchValue);
            }
        }

        private void CopyList(IList source, IList destination)
        {
            foreach (var item in source)
            {
                destination.Add(item);
            }
        }

        private void PinsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PinsNumericUpDown.Value > 1)
            {
                int newCount = (int)PinsNumericUpDown.Value;
                int delta = newCount - binaryPins.Count;
                if (delta < 0)
                {
                    for (int i = 0; i > delta; i--)
                    {
                        binaryPins.RemoveAt(binaryPins.Count - 1);
                        pinsFlowLayoutPanel.Controls.RemoveAt(pinsFlowLayoutPanel.Controls.Count - 1);
                    }
                }

                else
                {
                    for (int i = 0; i < delta; i++)
                    {
                        binaryPins.Add(new IndexNumericControl());
                        binaryPins[binaryPins.Count - 1].PinIndex = binaryPins.Count;
                        binaryPins[binaryPins.Count - 1].PinNumber = 0;
                        pinsFlowLayoutPanel.Controls.Add(binaryPins[binaryPins.Count - 1]);
                    }
                }
                RecalculateValueIndexes();
            }
            else PinsNumericUpDown.Value = 2;
        }

        private void LoadPinsPanel()
        {
            pinsFlowLayoutPanel.Controls.Clear();
            binaryPins.Clear();
            for (int i = 0; i < switch1.Pins.Count; i++)
            {
                binaryPins.Add(new IndexNumericControl());
                binaryPins[i].PinIndex = i;
                binaryPins[i].PinNumber = switch1.Pins[i];
                pinsFlowLayoutPanel.Controls.Add(binaryPins[i]);
            }
        }

        private void LoadValuesPanel()
        {
            valuesLayoutPanel.Controls.Clear();
            binaryValues.Clear();
            for (int i = 0; i < switch1.Values.Count; i++)
            {
                binaryValues.Add(new IndexValueControl());
                binaryValues[i].SwitchPosition = i;
                binaryValues[i].SwitchValue = switch1.Values[i];
                valuesLayoutPanel.Controls.Add(binaryValues[i]);
            }
        }

        private void RecalculateValueIndexes()
        {
            int newCount = (int)Math.Pow(2, Convert.ToDouble(PinsNumericUpDown.Value));
            valuesLabel.Text = newCount.ToString() + " Positions";
            int delta = newCount - binaryValues.Count;
            if (delta < 0)
            {
                for (int i = 0; i > delta; i--)
                {
                    binaryValues.RemoveAt(binaryValues.Count - 1);
                    valuesLayoutPanel.Controls.RemoveAt(valuesLayoutPanel.Controls.Count - 1);
                }
            }

            else
            {
                for (int i = 0; i < delta; i++)
                {
                    binaryValues.Add(new IndexValueControl());
                    binaryValues[binaryValues.Count - 1].SwitchPosition = binaryValues.Count;
                    binaryValues[binaryValues.Count - 1].SwitchValue = "0"; ;
                    valuesLayoutPanel.Controls.Add(binaryValues[binaryValues.Count - 1]);
                }
            }
        }


    }
}
