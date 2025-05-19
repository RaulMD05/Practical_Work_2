using System;
using Microsoft.Maui.Controls;

namespace practical_work_ii;

public partial class LoginPage : ContentPage
{
    private readonly UserStore userStore;

    public LoginPage()
    {
        InitializeComponent();
        userStore = new UserStore();

        var registerTap = new TapGestureRecognizer();
        registerTap.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new RegisterPage());
        };
        registerLabel.GestureRecognizers.Add(registerTap);

        var forgotTap = new TapGestureRecognizer();
        forgotTap.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        };
        forgotLabel.GestureRecognizers.Add(forgotTap);
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text?.Trim();
        string password = passwordEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Por favor, completa ambos campos.", "OK");
            return;
        }

        if (userStore.LoginUser(username, password))
        {
            await DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
            await Navigation.PushAsync(new CalculatorPage()); // Replace with your actual converter page
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }
    }
}
