using Microsoft.Maui.Controls;

namespace practical_work_ii
{
    public partial class UserInfo : ContentPage
    {
        public UserInfo(User user)//Receives the user that has Logged In and shows all of his info
        {
            InitializeComponent();

            nameLabel.Text = user.name;
            usernameLabel.Text = user.username;
            emailLabel.Text = user.email;
            passwordLabel.Text = user.password;
            n_OperationsLabel.Text = user.n_Operations.ToString();
        }

        private async void OnBackClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void OnExitClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
    }
}
