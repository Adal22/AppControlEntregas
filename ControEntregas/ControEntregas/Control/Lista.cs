using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControEntregas.Control
{
    public class Lista
    {
        public List<Model.EntregasModel> lientregas;
        public Lista()
        {
            lientregas = new List<Model.EntregasModel>();
            lientregas.Add(new Model.EntregasModel
            {
                ID = 1,
                Tema = "Entrega1",
                
            });
            lientregas.Add(new Model.EntregasModel
            {
                ID = 2,
                Tema = "Entrega2",
            });
            lientregas.Add(new Model.EntregasModel
            {
                ID = 3,
                Tema = "Entrega3",
            });
            lientregas.Add(new Model.EntregasModel
            {
                ID = 14,
                Tema = "Entrega4",
            });
            lientregas.Add(new Model.EntregasModel
            {
                ID = 16,
                Tema = "Entrega5",
            });


        }

   

    }


}
