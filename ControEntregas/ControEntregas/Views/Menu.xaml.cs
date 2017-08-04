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
        public Menu(Token token)
        {
            cliente.idCliente = Convert.ToInt64(token.customerID);
            InitializeComponent();

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            actLoading.IsRunning = true;
            await Task.Delay(2000);
            await Navigation.PushAsync(new EntregasV(cliente));
            actLoading.IsRunning = false;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (ordenN.Text != null && ordenN.Text != "")
            {
                actLoading.IsRunning = true;
                EntregasModel entrega = new EntregasModel();
                entrega.idOrdenEntrega = Convert.ToInt64(ordenN.Text.Trim());
                ordenN.Text = string.Empty;
                await Navigation.PushAsync(new DescripcionEntregas(entrega));
                actLoading.IsRunning = false;
            }
            else
            {
                await DisplayAlert("Error", "Favor de Introducir # de Orden", "cancel");
                ordenN.Focus();
            }
        }
    }
}