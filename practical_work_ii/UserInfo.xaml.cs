using Microsoft.Maui.Controls;

namespace practical_work_ii
{
    public partial class UserInfo : ContentPage
    {
        public UserInfo(User user)//Receives the user that has Logged In and shows all of his info
        {
            InitializeComponent();

            nameLabel.Text = user.Name;
            usernameLabel.Text = user.Username;
            emailLabel.Text = user.Email;
            passwordLabel.Text = user.Password;
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
