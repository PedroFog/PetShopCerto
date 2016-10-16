using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterPet2.App_Code.Camadas.DAL
{
    public class Clientes
    {
        public string strCon = DAL.Conexao.getConexao();


        public List<MODEL.Clientes> Select()
        {
            List<MODEL.Clientes> lstClientes = new List<MODEL.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Clientes";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.id = Convert.ToInt32(reader["id"].ToString());
                    cliente.nome = reader["nome"].ToString();
                    cliente.endereco = reader["endereco"].ToString();
                    cliente.nascimento = Convert.ToDateTime(reader["aniversario"].ToString());
                    cliente.idCidade = Convert.ToInt32(reader["id"].ToString());
                    lstClientes.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Erro na Seleção de Clientes");
            }
            finally
            {
                conexao.Close();
            }


            return lstClientes;
        }

        public void Insert(MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Clientes values (@idCidade, @nome, @telefone, @celular, @endereco, @cpf, @email)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCidade", cliente.idCidade);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@nascimento", cliente.nascimento);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.Clientes clientes)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Clientes set idCidade=@idCidade, nome=@nome, nascimento=@nascimento, endereco=endereco where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", clientes.id);
            cmd.Parameters.AddWithValue("@idCidade", clientes.idCidade);
            cmd.Parameters.AddWithValue("@nome", clientes.nome);
            cmd.Parameters.AddWithValue("@nascimento", clientes.nascimento);
            cmd.Parameters.AddWithValue("@endereco", clientes.endereco);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Clientes");
            }
            finally
            {
                conexao.Close();
            }

        }
        public void Delete(MODEL.Clientes clientes)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Clientes where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", clientes.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Clientes");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}