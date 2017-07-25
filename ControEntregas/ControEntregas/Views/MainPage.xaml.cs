using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ControEntregas;

namespace ControEntregas
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();            
            
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                BtnLogin.IsEnabled = false;
                MainPro.IsVisible = true;
                Button button = sender as Button;
                Services.UserServices postUer = new Services.UserServices();
                Model.Login data = new Model.Login(UserLg.Text, PassLg.Text);
                // bool res = await postUer.PostUserAsync(data);
                bool res = true;
                await MainPro.ProgressTo(1, 1000, Easing.Linear);
                
                MainPro.IsVisible = false;
                if (res == true)
                {
                    // App.Current.MainPage = new Menu();
                 
                  await Navigation.PushAsync(new Menu());
                }
                else
                {
                    await DisplayAlert("Warning!", "Usuario o Contraseña Incorrecto", "cancel");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", ex.ToString(), "cancel");
            }
                      
         
            
    
        }

       
    }
}
