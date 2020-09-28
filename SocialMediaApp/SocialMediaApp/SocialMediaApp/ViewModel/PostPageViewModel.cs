using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Plugin.CloudFirestore;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SocialMediaApp.Helpers;
using SocialMediaApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace SocialMediaApp.ViewModel
{
    public class PostPageViewModel : INotifyPropertyChanged
    {
        FireBaseStorageHelper firebaseStorageHelper = new FireBaseStorageHelper();

        MediaFile file;



        public PostPageViewModel()
        {
            ShareCommand = new MvvmHelpers.Commands.Command(SharePost);
            imgPickCommand = new AsyncCommand(imgpick);
        }

        public ICommand ShareCommand { get; }

        public IAsyncCommand imgPickCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ImageSource imgsource = string.Empty;
        public ImageSource ImgSource
        {
            get { return imgsource; }
            set { imgsource = value; OnPropertyChanged(); }
        }

        string posttxt = string.Empty;
        public string PostText
        {
            get { return posttxt; }

            set { posttxt = value; OnPropertyChanged(); }
        }
        Post newpost = new Post();
        byte[] ba;

        public async void SharePost()
        {
            newpost.PostTxt = PostText;
            ba = Encoding.Default.GetBytes(newpost.PostTxt);
            var hexstring = BitConverter.ToString(ba);

            await CrossCloudFirestore.Current.Instance.GetCollection("Posts").GetDocument(hexstring).SetDataAsync(newpost);
            PostText = "";
        }

      
        public async Task imgpick()
        {
            await CrossMedia.Current.Initialize();

            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                    return;
               ImgSource = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }





    }
}
