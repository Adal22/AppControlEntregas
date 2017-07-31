using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Model;
using ControEntregas.Services;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace ControEntregas.Model
{
    public class ViewModels 
    {
        public List<EntregasM> EntregasList { get; set; }

        public  ViewModels()
        {
            EntregasList = new List<EntregasM>();
            // InitializeDataAsync();
            //this.InitializeDataAsync();
            Task.Run(() => this.InitializeDataAsync()).Wait();
        }

        private async Task InitializeDataAsync()
        {
            var entregasService = new EntregasServices();
            EntregasList = await entregasService.GetEntregasAsync();
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{

        //}
    }
}
