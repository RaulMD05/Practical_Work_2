using System;
using Microsoft.Maui.Controls;
using practical_work_ii;
using System.Collections.Generic;

namespace practical_work_ii
{
    public partial class CalculatorPage : ContentPage
    {
        private List<Conversion> conversions;

        public CalculatorPage()
        {
            InitializeComponent();

            this.conversions = new List<Conversion>();

            this.conversions.Add(new DecimalToBinary("Binary", "Decimal to binary"));
            this.conversions.Add(new DecimalToOctal("Octal", "Decimal to octal"));
            this.conversions.Add(new DecimalToHex("Hex", "Decimal to hexadecimal"));
            this.conversions.Add(new DecimalToTwosComplement("Twos Complement", "Decimal to binary (2Complement)"));
            this.conversions.Add(new BinaryToDecimal("Decimal", "Binary To Decimal"));
            this.conversions.Add(new TwoComplementToDecimal("Decimal", "Binary(2Complement) to Decimal"));
            this.conversions.Add(new OctaToDecimal("Decimal", "Octal To Decimal"));
            this.conversions.Add(new HexToDecimal("Decimal", "Hex To Decimal"));

        }

        private void OnInputButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                inputEntry.Text += button.Text;
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            inputEntry.Text = string.Empty;
        }

        private async void OnConversionClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string name = button.Text.Trim();
                string input = inputEntry.Text?.Trim() ?? "";

                Conversion converter = null;
                foreach (var c in conversions)
                {
                    if (c.GetName() == name)
                    {
                        converter = c;
                        break;
                    }
                }

                if (converter == null)
                {
                    await DisplayAlert("Error", $"Conversion '{name}' is not available.", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    await DisplayAlert("Error", "Please enter a value to convert.", "OK");
                    return;
                }

                try
                {
                    converter.validate(input);

                    string result;

                    if (converter.NeedBitSize())
                    {
                        result = converter.Change(input, 8);
                    }
                    else
                    {
                        result = converter.Change(input);
                    }

                    await DisplayAlert("Result", $"{input} → {result}", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Conversion Error", ex.Message, "OK");
                    inputEntry.Text = string.Empty;
                }
            }
        }
    }
}
