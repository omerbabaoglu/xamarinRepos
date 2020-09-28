using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialMediaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageGrid : ContentPage
    {
        IAuth auth;
        public LoginPageGrid()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void GoToRegisterPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }

        async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string token = await auth.LoginWithEmailAndPassword(UsersMail.Text, UsersPassword.Text);
            if (token != string.Empty)
            {
                Application.Current.MainPage = new MainTabbedPage();
            }else
            {
                await DisplayAlert("Authentication Failed", "Email or password are incorrect", "OK");
            }

        }

    }
}