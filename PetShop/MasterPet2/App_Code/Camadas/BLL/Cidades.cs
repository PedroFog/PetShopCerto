using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.BLL
{
    public class Cidades
    {


        public void Insert(MODEL.Cidades cidades)
        {
            DAL.Cidades dalCida = new DAL.Cidades();
            dalCida.Insert(cidades);
        }

        public List<MODEL.Cidades> Select()
        {
            DAL.Cidades dalCida = new DAL.Cidades();
            return dalCida.Select();
        }

        public void Update(MODEL.Cidades cidades)
        {
            DAL.Cidades dalCida = new DAL.Cidades();
            dalCida.Update(cidades);
        }

        public void Delete(MODEL.Cidades cidades)
        {
            DAL.Cidades dalCida = new DAL.Cidades();
            dalCida.Delete(cidades);
        }

    }
}