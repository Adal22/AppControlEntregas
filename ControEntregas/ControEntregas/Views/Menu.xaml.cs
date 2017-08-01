using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ControEntregas.Model;

namespace ControEntregas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        Cliente cliente = new Cliente();
        public Menu()
        {
            cliente.idCliente = 1;
            InitializeComponent();
        }
      
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntregasV(cliente));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var imageSender = (Image)sender;
            await Navigation.PushAsync(new EntregasV(cliente));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
           if( ordenN.Text != null && ordenN.Text != "" )
            {

            }
           else
            {
                await DisplayAlert("Warning!", "Favor de Introducir # de Orden", "cancel");
                ordenN.Focus();
            }
        }
    }
}