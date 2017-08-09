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
using Plugin.Geolocator;
using ControEntregas.Model;
using System.IO;

namespace ControEntregas.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signature : ContentPage
    {
        private HistorialEntregaModel info;
        private MediaFile foto;
        public Signature(HistorialEntregaModel info)
        {
            this.info = info;
            this.info.idUsuario = this.info.token.userID;
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (foto != null)
                {
                    btnEnviarInformacion.IsEnabled = false;
                    actLoading.IsRunning = true;
                    var firma = padView.GetImage(ImageFormatType.Jpg);
                    var position = await CrossGeolocator.Current.GetPositionAsync();
                    info.latitud = position.Latitude.ToString();
                    info.longitud = position.Longitude.ToString();
                    info.firmas.Add(this.GetAsByteArray(firma)); //is converted to byte array
                    info.fotos.Add(this.GetAsByteArray(foto.GetStream()));

                    HistorialEntregaServices service = new HistorialEntregaServices();
                    await service.PostHistorialEntregas(info);

                    actLoading.IsRunning = false;
                    await DisplayAlert("Enviado", "La información ha sido enviada correctamente", "Ok");
                    btnEnviarInformacion.IsEnabled = true;
                    await this.ReturnToMenu();
                }
                else
                {
                    await DisplayAlert("Error", "Tome una foto antes de enviar", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                actLoading.IsRunning = false;
                btnEnviarInformacion.IsEnabled = true;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                actLoading.IsRunning = true;
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camara", "No es Compatible", "OK");
                    return;
                }
                foto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Control_entregas",
                    SaveToAlbum = true,
                    Name = "test.jpg",
                    RotateImage = true
                });

                if (foto == null)
                    return;

                imgPhoto.Source = ImageSource.FromStream(() => foto.GetStream());
                imgPhoto.WidthRequest = 120;
                imgPhoto.HeightRequest = 100;

                actLoading.IsRunning = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al accionar la cámara", "Ok");
            }
        }

        private byte[] GetAsByteArray(Stream input)
        {
            input.Position = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                input.Dispose();
                return ms.ToArray();
            }
        }

        private async Task ReturnToMenu()
        {
            Navigation.InsertPageBefore(new Menu(this.info.token), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }
    }
}