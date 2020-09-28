using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Plugin.CloudFirestore;
using SocialMediaApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocialMediaApp.ViewModel
{
    public class FeedViewModel : INotifyPropertyChanged
    {
       
        public FeedViewModel()
        {

            GetPostCommand = new AsyncCommand(GetPosts);
            GetPosts();


        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<Post> postss;
        public List<Post> postlar
        {
            get { return postss; }
            set { postss = value; OnPropertyChanged(); }

        }


        public async Task GetPosts()
        {


            var group = await CrossCloudFirestore.Current.Instance.GetCollectionGroup("Posts").GetDocumentsAsync();

            var yourModels = group.ToObjects<Post>();


            postlar = yourModels.ToList();
            OnPropertyChanged(nameof(postlar));

        }




        public IAsyncCommand GetPostCommand
        {
            get;
        }

    }
}

