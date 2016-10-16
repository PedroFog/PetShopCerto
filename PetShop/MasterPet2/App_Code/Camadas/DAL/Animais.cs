using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.DAL
{
    public class Animais
    {
        public string strCon = Conexao.getConexao();

        public List<MODEL.Animais> Select()
        {
            List<MODEL.Animais> lstAnimais = new List<MODEL.Animais>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Animais";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Animais animais = new MODEL.Animais();
                    animais.id = Convert.ToInt32(reader["id"]);
                    animais.nome = reader["nome"].ToString();
                    animais.raca = reader["raca"].ToString();
                    animais.especie = reader["especie"].ToString();
                    animais.cor = reader["cor"].ToString();
                    animais.sexo = Convert.ToChar(reader["sexo"]);
                    animais.nascimento = Convert.ToDateTime(reader["nascimento"]);
                    lstAnimais.Add(animais);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na seleção de Animais");
            }
            finally
            {
                conexao.Close();
            }
            return lstAnimais;
        }

        public void Insert(MODEL.Animais animais)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Clientes values (@idClientes, @nome, @raca, @especie, @cor, @sexo, @nascimento)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idClientes", animais.idClientes);
            cmd.Parameters.AddWithValue("@nome", animais.nome);
            cmd.Parameters.AddWithValue("@raca", animais.raca);
            cmd.Parameters.AddWithValue("@especie", animais.especie);
            cmd.Parameters.AddWithValue("@cor", animais.cor);
            cmd.Parameters.AddWithValue("@sexo", animais.sexo);
            cmd.Parameters.AddWithValue("@nascimento", animais.nascimento);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Animais...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Animais animais) 
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Animais set idClientes=@idClientes, nome=@nome, raca=@raca," +
                "especie=@especie, cor=@cor, sexo=@sexo, nascimento=@nascimento where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", animais.id);
            cmd.Parameters.AddWithValue("@idClientes", animais.idClientes);
            cmd.Parameters.AddWithValue("@nome", animais.nome);
            cmd.Parameters.AddWithValue("@raca", animais.raca);
            cmd.Parameters.AddWithValue("@especie", animais.especie);
            cmd.Parameters.AddWithValue("@cor", animais.cor);
            cmd.Parameters.AddWithValue("@sexo", animais.sexo);
            cmd.Parameters.AddWithValue("@nascimento", animais.nascimento);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Animais");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(MODEL.Animais animais)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Animais where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", animais.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Animais");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}