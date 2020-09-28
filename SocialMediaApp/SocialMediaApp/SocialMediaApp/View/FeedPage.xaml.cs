using Plugin.CloudFirestore;
using SocialMediaApp.Model;
using SocialMediaApp.View;
using SocialMediaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.App.DownloadManager;

namespace SocialMediaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class FeedPage : ContentPage
    {
    
        public FeedPage()
        {          
            InitializeComponent();
            
            BindingContext = new FeedViewModel();
        }

        

       
    }
}