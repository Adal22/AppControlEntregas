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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescripcionEntregas : ContentPage
    {
        ViewModels viewModel;
        public DescripcionEntregas()
        {
            InitializeComponent();
            BindingContext = viewModel = new ViewModels();
        }

        

    }
}