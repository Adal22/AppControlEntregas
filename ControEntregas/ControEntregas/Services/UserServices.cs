using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Model;
using System.Net.Http;

namespace ControEntregas.Services
{
    public class UserServices
    {
        public async Task<bool> PostUserAsync(Login data)
        {
            try
            {
                var httpClient = new HttpClient();
                var httpContent = new FormUrlEncodedContent(new[]
                 {
                    new KeyValuePair<string,string>("userName",data.userName),
                    new KeyValuePair<string,string>("password",data.password),
                    new KeyValuePair<string,string>("grant_type", data.grant_type)
                });
                var result = await httpClient.PostAsync(String.Format("{0}token", APISettings.API_URL), httpContent).ConfigureAwait(false);
                string token = await result.Content.ReadAsStringAsync();
                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
