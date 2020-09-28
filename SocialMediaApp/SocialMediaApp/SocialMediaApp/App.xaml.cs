using SocialMediaApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialMediaApp
{
    public partial class App : Application
    {
        IAuth auth;
        public App()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            if (auth.IsSignIn())
            {
                MainPage = new MainTabbedPage();
            }
            else
            {
                MainPage = new LoginPageGrid();
            }
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
