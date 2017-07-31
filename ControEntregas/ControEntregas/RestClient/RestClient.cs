using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using ControEntregas.Model;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {
        private const string WebServiceUrl = "http://un-app-01:8085/token";
        private const string WebServiceUrl2 = "http://un-app-01:8085/api/Clientes/1/OrdenesEntrega/3";

        public async Task<List<T>> GetAsync()
        {
            try
            {
                var httpClient = new HttpClient();

                var json = await httpClient.GetStringAsync(WebServiceUrl2);

                var taskModels =  JsonConvert.DeserializeObject<List<T>>(json);

                return taskModels;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> PostAsync(T t)
        {
            try
            {

                var httpClient = new HttpClient();

                var json = JsonConvert.SerializeObject(t);
                HttpContent httpContent = new StringContent(json,Encoding.UTF8, "application/json");
         
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(WebServiceUrl, httpContent);
                return result.IsSuccessStatusCode;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PostAsync2(Login Data)
        {
            try
            {

                var httpClient = new HttpClient();

                var httpContent = new FormUrlEncodedContent(new[]
                 {
                    new KeyValuePair<string,string>("userName",Data.userName),
                    new KeyValuePair<string,string>("password",Data.password),
                    new KeyValuePair<string,string>("grant_type", Data.grant_type)
                });
                var result = await httpClient.PostAsync(WebServiceUrl, httpContent);
                string token = await result.Content.ReadAsStringAsync();
                return result.IsSuccessStatusCode;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
    }
}
