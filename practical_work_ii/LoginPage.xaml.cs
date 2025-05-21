using System;
using Microsoft.Maui.Controls;

namespace practical_work_ii;

public partial class LoginPage : ContentPage
{
    private UserStore userStore;
    private User loginUser;
    private string filePath = "Files\\Users.csv";



    public LoginPage()
    {
        InitializeComponent();
        userStore = new UserStore();
        loginUser = new User();

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

        if (username == null || username == "" || password == null || password == "")
        {
            await DisplayAlert("Error", "Por favor, completa ambos campos.", "OK");
            return;
        }

        if (userStore.LoginUser(username, password))
        {
            GetUser(username,password);
            await DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
            await Navigation.PushAsync(new CalculatorPage(loginUser)); // Replace with your actual converter page
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }
    }
        public void GetUser(string username, string password)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length >= 4 && parts[1] == username && parts[3] == password)
                {
                    loginUser.Name = parts[0];
                    loginUser.Username = parts[1];
                    loginUser.Email = parts[2];
                    loginUser.Password = parts[3];
                    loginUser.n_Operations = Int32.Parse(parts[4]);    
                }
                    
            }
        }
}
