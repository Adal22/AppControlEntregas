using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControEntregas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntregasV : ContentPage
    {
        private ViewModelsEntregas viewModel;
        public EntregasV(Cliente cliente)
        {
            Title = "Órdenes de entrega";
            InitializeComponent();
            try
            {
                BindingContext = viewModel = new ViewModelsEntregas(cliente); //set binding in this class
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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            EntregasModel data = (EntregasModel)e.Item;
            Navigation.PushAsync(new DescripcionEntregas(data));
        }
    }
}