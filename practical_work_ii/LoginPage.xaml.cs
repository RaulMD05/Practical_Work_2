using System;
using Microsoft.Maui.Controls;

namespace practical_work_ii;

public partial class LoginPage : ContentPage
{
    private readonly UserStore _userStore;

    public LoginPage()
    {
        InitializeComponent();
        _userStore = new UserStore();

        var registerTap = new TapGestureRecognizer();
        registerTap.Tapped += async (s, e) =>
        {
            await DisplayAlert("Info", "Ir a registro (placeholder)", "OK");
        };
        registerLabel.GestureRecognizers.Add(registerTap);

        var forgotTap = new TapGestureRecognizer();
        forgotTap.Tapped += async (s, e) =>
        {
            await DisplayAlert("Info", "Recuperar contraseña (placeholder)", "OK");
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

        if (_userStore.LoginUser(username, password))
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
