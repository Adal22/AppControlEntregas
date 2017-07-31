using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ControEntregas.Views
{
    public class Entregas : ContentPage
    {
        private ListView list = new ListView();
        public Entregas()
        {
            Control.Lista listaEntregas = new Control.Lista();
            // MessagingCenter.Subscribe<Page>(this, "Update", messageCallback);
            list.ItemsSource = listaEntregas.lientregas;
            list.ItemTemplate = new DataTemplate(typeof(EntregasView));
            list.ItemTapped += listItemTapped_Tapped;
            Content = list;
        }

        private void messageCallback(Page obj)
        {
            //Control.Lista listaFugitivos = new Control.Lista();
           // list.ItemsSource = listaFugitivos.lientregas;
        }
        public void listItemTapped_Tapped(object sender, ItemTappedEventArgs args)
        {
            Model.EntregasModel Entrega = (Model.EntregasModel)args.Item;
            Navigation.PushAsync(new Views.DescripcionEntregas());
        }
    }
}