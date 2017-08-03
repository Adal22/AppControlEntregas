using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;

namespace ControEntregas.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescripcionEntregas : ContentPage
    {
        ViewModels viewModel;
        private EntregasModel data;
        public DescripcionEntregas(EntregasModel data)
        {
            this.data = data;
            InitializeComponent();
            if (data.descripcion != null)
            {
                Title = data.descripcion;
            }

            try
            {
                BindingContext = viewModel = new ViewModels(data.idOrdenEntrega);
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await this.DisplayAlert("Error", ex.InnerException.Message, "OK");
                    await this.Navigation.PopAsync(); // or anything else
                });
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signature());
        }
    }
}