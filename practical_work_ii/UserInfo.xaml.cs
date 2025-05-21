using Microsoft.Maui.Controls;

namespace practical_work_ii
{
    public partial class UserInfo : ContentPage
    {
        public UserInfo(string name, string username, string password, int operationsCount)
        {
            InitializeComponent();

            nameLabel.Text = name;
            usernameLabel.Text = username;
            passwordLabel.Text = password;
            operationsCountLabel.Text = operationsCount.ToString();
        }

        private async void OnBackClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
