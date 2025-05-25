using System;
using Microsoft.Maui.Controls;
using practical_work_ii;
using System.Collections.Generic;

namespace practical_work_ii
{
    public partial class CalculatorPage : ContentPage
    {
        private List<Conversion> conversions;
        private User currentUser;

        public CalculatorPage(User user)
        {
            InitializeComponent();

            this.conversions = new List<Conversion>();

            this.conversions.Add(new DecimalToBinary("Binary", "DecimalToBinary"));
            this.conversions.Add(new DecimalToOctal("Octal", "DecimalToOctal"));
            this.conversions.Add(new DecimalToHex("Hex", "DecimalToHex"));
            this.conversions.Add(new DecimalToTwosComplement("Twos Complement", "DecimalToTwosComplement"));
            this.conversions.Add(new BinaryToDecimal("Decimal", "BinaryToDecimal"));
            this.conversions.Add(new TwoComplementToDecimal("Decimal", "TwosComplementToDecimal"));
            this.conversions.Add(new OctaToDecimal("Decimal", "OctalToDecimal"));
            this.conversions.Add(new HexToDecimal("Decimal", "HexToDecimal"));//Adds all of the conversions, to a list

            this.currentUser = user;
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
            inputEntry.Text = string.Empty;//Empties the input
        }

        private async void OnConversionClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string name = button.Text;  //gets the name of the conversion the person wants to do
                string input = inputEntry.Text?.Trim() ?? "";   //Input inserted

                Conversion converter = null;
                foreach (Conversion c in conversions)
                {
                    if (c.GetDefinition() == name)//Searchs the name of the operation he wants to do, and stores it
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
                    currentUser.n_Operations++;
                    await DisplayAlert("Result", $"{input} → {result}", "OK");// Calculates the result, and shows you
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Conversion Error", ex.Message, "OK");
                    inputEntry.Text = string.Empty;
                }
            }
        }
        private async void OnShowUserInfoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserInfo(currentUser));  //Whenever you click this, it will get you to the User Info Page
        }
        private void OnExitClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }


    }
}
