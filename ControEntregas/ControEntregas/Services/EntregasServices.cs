using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControEntregas.Model;
using Plugin.RestClient;

namespace ControEntregas.Services
{
    public class EntregasServices
    {
        public async Task<List<EntregasM>> GetEntregasAsync()
        {
            RestClient<EntregasM> restClient = new RestClient<EntregasM>();
            var entregasList = await restClient.GetAsync();
            return entregasList;
        }
    }
}
