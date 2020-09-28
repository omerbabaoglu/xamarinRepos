using System.IO;
using System.Threading.Tasks;
using Firebase.Storage;

namespace SocialMediaApp.Helpers
{
    public  class FireBaseStorageHelper
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("fir-sample-cec98.appspot.com");

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }

        public async Task<string> GetFile(string fileName)
        {
            return await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }
    }
}
