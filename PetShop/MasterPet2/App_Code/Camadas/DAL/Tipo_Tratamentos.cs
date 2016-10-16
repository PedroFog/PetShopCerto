using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.DAL
{
    public class Tipo_Tratamentos
    {
        public string strCon = Conexao.getConexao();


        public List<MODEL.Tipo_Tratamentos> Select()
        {
            List<MODEL.Tipo_Tratamentos> lstTipo_Tratamentos = new List<MODEL.Tipo_Tratamentos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Tipo_Tratamentos";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Tipo_Tratamentos tipo_tratamentos = new MODEL.Tipo_Tratamentos();
                    tipo_tratamentos.id = Convert.ToInt32(reader["id"].ToString());
                    tipo_tratamentos.descri = reader["nome"].ToString();
                    tipo_tratamentos.preco = Convert.ToSingle(reader["preco"]);
                    lstTipo_Tratamentos.Add(tipo_tratamentos);
                }
            }
            catch
            {
                Console.WriteLine("Erro na Seleção de Tipo Tratamentos");
            }
            finally
            {
                conexao.Close();
            }


            return lstTipo_Tratamentos;
        }

        public void Insert(MODEL.Tipo_Tratamentos tipoTratamento)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Tipo_Tratamentos value(@descricao, @preco)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@descricao", tipoTratamento.descri);
            cmd.Parameters.AddWithValue("@preco", tipoTratamento.preco);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                Console.WriteLine("Deu erro na inserção de Tipo_Tratamentos");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Tipo_Tratamentos tipoTratamento)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Tipo_Tratamentos set descricao=@descricao, ";
            sql += " preco=@preco where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", tipoTratamento.id);
            cmd.Parameters.AddWithValue("@descricao", tipoTratamento.descri);
            cmd.Parameters.AddWithValue("@preco", tipoTratamento.preco);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Tipo Tratamento");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Tipo_Tratamentos tipoTratamento)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Tipo_Tratamentos where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", tipoTratamento.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Tipo Tratamento...");
            }
            finally
            {
                conexao.Close();
            }

        }




    }
}