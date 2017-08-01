using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.XamForms.SignaturePad;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ControEntregas.Services;

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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           
        }
    }
}