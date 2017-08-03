using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.XamForms.SignaturePad;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ControEntregas.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace ControEntregas.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signature : ContentPage
    {
       
        public Signature()
        {
            InitializeComponent();
        }

        private  void Button_Clicked(object sender, EventArgs e)
        {
            var image = padView.GetImage(ImageFormatType.Png);
           
        }

        private async void Upload_Clicked(object sender, EventArgs e)
        {
           
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camara", "No es Compatible", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
           
            if (file == null)
                return;

        //    Image1.Source = ImageSource.FromStream(() => file.GetStream());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camara", "No es Compatible", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                //Directory = "test",
                SaveToAlbum = true,
                Name = "test.jpg"

            });

            if (file == null)
                return;
           
            Image1.Source = ImageSource.FromStream(() => file.GetStream());
            Image1.WidthRequest = 120;
            Image1.HeightRequest = 120;
            
        }
    }
}