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
    public partial class ProfilePage : ContentPage
    {
        IAuth auth;
        public ProfilePage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

        }

        private void SignOutButton_Clicked(object sender, EventArgs e)
        {
            var SignOut = auth.SignOut();
            if (SignOut)
            {
                Application.Current.MainPage = new LoginPageGrid();
            }
        }
    }
}