using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ControEntregas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();

        }
        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entregas());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var imageSender = (Image)sender;
            await Navigation.PushAsync(new Entregas());
        }
    }
}