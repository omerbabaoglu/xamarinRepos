﻿using Plugin.CloudFirestore;
using SocialMediaApp.Model;
using SocialMediaApp.ViewModel;
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
    public partial class PostPage : ContentPage
    {
        
        
       
        public PostPage()
        {
            InitializeComponent();

            BindingContext = new PostPageViewModel();
            
        }

       
    }

    
}