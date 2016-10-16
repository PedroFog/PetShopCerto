using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.DAL
{
    public class Tratamentos
    {
        public string strCon = Conexao.getConexao();

        public List<MODEL.Tratamentos> Select()
        {
            List<MODEL.Tratamentos> lstTratamentos = new List<MODEL.Tratamentos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Tratamentos";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Tratamentos tratamentos = new MODEL.Tratamentos();
                    tratamentos.id = Convert.ToInt32(reader["id"].ToString());
                    tratamentos.idTipo_tratamento = Convert.ToInt32(reader["idTipo_tratamento"].ToString());
                    lstTratamentos.Add(tratamentos);
                }
            }
            catch
            {
                Console.WriteLine("Erro na Seleção de Tratamentos");
            }
            finally
            {
                conexao.Close();
            }


            return lstTratamentos;
        }

        public void Insert(MODEL.Tratamentos tratamentos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into tratamentos values (@idTipo_tratamentos)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idTipo_tratamentos", tratamentos.idTipo_tratamento);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

                Console.WriteLine("Deu Erro na inserção de Tratamentos");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Tratamentos tratamentos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update tratamentos set idTipo_tratamento=@idTipo_tratamento ";
            sql += " where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", tratamentos.id);
            cmd.Parameters.AddWithValue("@idTipo_tratamento", tratamentos.idTipo_tratamento);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Tratamento");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Tratamentos tratamentos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Tratamentos where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", tratamentos.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Tratamentos...");
            }
            finally
            {
                conexao.Close();
            }

        }


    }
}