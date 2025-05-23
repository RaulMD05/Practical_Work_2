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
            await Navigation.PushAsync(new RegisterPage());//Sends you to the register page
        };
        registerLabel.GestureRecognizers.Add(registerTap);  

        var forgotTap = new TapGestureRecognizer();
        forgotTap.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new ForgotPasswordPage());//Sends you to the Forgot password page
        };
        forgotLabel.GestureRecognizers.Add(forgotTap);
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text?.Trim();
        string password = passwordEntry.Text?.Trim();

        if (username == null || username == "" || password == null || password == "")
        {
            await DisplayAlert("Error", "Please enter both Username and Password", "OK");
            return;
        }

        if (userStore.LoginUser(username, password))// Checks the login
        {
            GetUser(username, password);//Searchs for the user, to complete all its sections
            await DisplayAlert("Great!", "Sign-In was correct", "OK");
            await Navigation.PushAsync(new CalculatorPage(loginUser)); // Replace with your actual converter page
        }
        else
        {
            await DisplayAlert("Error", "Username or Password are not correct.\nPlease try again", "OK");
        }
    }
    public void GetUser(string username, string password)//Saves all the info of the user on an auxiliar User, to send it to the user info
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            if (parts.Length >= 4 && parts[1] == username && parts[3] == password)
            {
                loginUser.name = parts[0];
                loginUser.username = parts[1];
                loginUser.email = parts[2];
                loginUser.password = parts[3];
                loginUser.n_Operations = Int32.Parse(parts[4]);
            }

        }
    }
    private void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();//When the exit button is clicked, the program closes
    }
}
