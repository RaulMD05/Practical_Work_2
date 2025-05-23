using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace practical_work_ii;

public partial class ForgotPasswordPage : ContentPage
{
    private string filePath = "Files\\Users.csv";

    public ForgotPasswordPage()
    {
        InitializeComponent();
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text?.Trim();

        if (email == null || email == "")
        {
            await DisplayAlert("Error", "Please enter your email.", "OK");
            return;
        }

        if (!File.Exists(filePath))
        {
            await DisplayAlert("Error", "User file not found.", "OK");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');

            if (parts.Length >= 4)
            {
                string savedEmail = parts[2];
                string savedPassword = parts[3];

                if (savedEmail == email)
                {
                    await DisplayAlert("Your Password", $"Your password is: {savedPassword}", "OK");//Searchs for the email you introduced in the csv, and shows the password
                    return;
                }
            }
        }

        await DisplayAlert("Error", "Email not found.", "OK");
    }
        private void OnExitClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
}
