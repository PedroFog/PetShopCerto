using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.MODEL
{
    public class Animais
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string raca { get; set; }
        public string especie { get; set; }
        public string cor { get; set; }
        public char sexo { get; set; }
        public DateTime nascimento { get; set; }
        public int idClientes { get; set; }
    }
}