using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.MODEL
{
    public class Clientes
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime nascimento { get; set; }
        public string endereco { get; set; }
        public int idCidade { get; set; }


    }
}