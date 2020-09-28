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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void GoToLoginPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPageGrid());
        }

        async void RegisterWithMail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterWithMailPage());
        }
    }
}