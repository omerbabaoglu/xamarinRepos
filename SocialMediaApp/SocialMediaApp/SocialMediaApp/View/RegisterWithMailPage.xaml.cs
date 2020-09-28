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
    public partial class RegisterWithMailPage : ContentPage
    {
        IAuth auth;
        public RegisterWithMailPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void BackToLoginPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPageGrid());
        }

        async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            var user = auth.SignUpWithEmailAndPassword(MailEntry.Text, PasswordEntry.Text);
            if (user != null)
            {
                await DisplayAlert("Succes", "New User Created", "OK");
                var signOut = auth.SignOut();
                if (signOut)
                {
                    Application.Current.MainPage = new LoginPageGrid();
                }
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong", "OK");
            }

        }
    }
}