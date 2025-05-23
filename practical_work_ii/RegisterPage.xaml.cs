using Microsoft.Maui.Controls;
using System;

namespace practical_work_ii;

public partial class RegisterPage : ContentPage
{
    private readonly UserStore userStore;

    public RegisterPage()
    {
        InitializeComponent();
        userStore = new UserStore();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text?.Trim();
        string username = usernameEntry.Text?.Trim();
        string email = emailEntry.Text?.Trim();
        string password = passwordEntry.Text?.Trim();
        string confirmPassword = confirmPasswordEntry.Text?.Trim();
        bool acceptedPolicy = policyCheckBox.IsChecked;

        bool success = userStore.RegisterUser(name, username, email, password, confirmPassword, acceptedPolicy);//It tried to register all the info inserted 

        if (success)
        {
            await DisplayAlert("Success", "User registered successfully", "OK");
            await Navigation.PopAsync(); // Go back to the login
        }
        else
        {
            await DisplayAlert("Error", "Check all fields and password requirements", "OK");
        }
    }
    private void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}
