using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.DAL
{
    public class Cidades
    {
        public string strCon = DAL.Conexao.getConexao();

        public List<MODEL.Cidades> Select()
        {
            List<MODEL.Cidades> lstCidades = new List<MODEL.Cidades>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Cidades";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Cidades cidades = new MODEL.Cidades();
                    cidades.id = Convert.ToInt32(reader["id"].ToString());
                    cidades.nome = reader["nome"].ToString();
                    cidades.uf = reader["uf"].ToString();
                    lstCidades.Add(cidades);
                }
            }
            catch
            {
                Console.WriteLine("Erro na Seleção de Cidades");
            }
            finally
            {
                conexao.Close();
            }


            return lstCidades;
        }

        public void Insert(MODEL.Cidades cidade)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Cidades values (@nome, @uf)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cidade.nome);
            cmd.Parameters.AddWithValue("@uf", cidade.uf);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Cidades...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Cidades cidades)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Cidades set nome=@nome, ";
            sql += " uf=@uf where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cidades.id);
            cmd.Parameters.AddWithValue("@nome", cidades.nome);
            cmd.Parameters.AddWithValue("@uf", cidades.uf);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Cidades");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Cidades cidades)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Cidades where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cidades.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Cidades...");
            }
            finally
            {
                conexao.Close();
            }

        }


    }

}