using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.BLL
{
    public class Animais
    {
        

        public void Insert(MODEL.Animais animais)
        {
            DAL.Animais dalAnim = new DAL.Animais();
            dalAnim.Insert(animais);
        }

        public List<MODEL.Animais> Select()
        {
            DAL.Animais dalAnim = new DAL.Animais();
            return dalAnim.Select();
        }


        public void Update(MODEL.Animais animais)
        {
            DAL.Animais dalAnim = new DAL.Animais();
            dalAnim.Update(animais);
        }

        public void Delete(MODEL.Animais animais)
        {
            DAL.Animais dalAnim = new DAL.Animais();
            dalAnim.Delete(animais);
        }


    }
}