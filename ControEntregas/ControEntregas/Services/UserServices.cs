using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Model;
using Plugin.RestClient;


namespace ControEntregas.Services
{
    public class UserServices
    {
        public async Task<List<Login>> GetUserAsync()
        {
            RestClient<Login> restClient = new RestClient<Login>();
            var user = await restClient.GetAsync();
            return user;
        }

        public async Task<bool> PostUserAsync(Login data)
        {
            try
            {
                RestClient<Login> restClient = new RestClient<Login>();
                // var user = await restClient.PostAsync(data);
                //bool res =  await restClient.IniciarLoggin(data);
                return await restClient.PostAsync2(data);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
