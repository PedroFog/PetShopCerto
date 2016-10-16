using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.DAL
{
    public class Animais_Tratamento
    {
        public string strCon = Conexao.getConexao();

        public void Insert(MODEL.Animais_Tratamento animaisTratamento)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Animais_Tratamento values(@idTratamento, @idAnimais)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idTratamento", animaisTratamento.idTratamento);
            cmd.Parameters.AddWithValue("@idAnimais", animaisTratamento.idAnimais);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                Console.WriteLine("Deu erro na inserção de Animais_Tratamento");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}