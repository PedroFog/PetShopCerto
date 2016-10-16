using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.BLL
{
    public class Clientes
    {



        public void Insert(MODEL.Clientes clientes)
        {
            DAL.Clientes dalCli = new DAL.Clientes();
            dalCli.Insert(clientes);
        }

        public List<MODEL.Clientes> Select()
        {
            DAL.Clientes dalCli = new DAL.Clientes();
            return dalCli.Select();
        }

        public void Update(MODEL.Clientes clientes)
        {
            DAL.Clientes dalCli = new DAL.Clientes();
            dalCli.Update(clientes);
        }

        public void Delete(MODEL.Clientes clientes)
        {
            DAL.Clientes dalCli = new DAL.Clientes();
            dalCli.Delete(clientes);
        }


    }
}