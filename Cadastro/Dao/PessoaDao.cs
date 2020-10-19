using Cadastro.model;
using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace Cadastro.Dao
{
    class PessoaDao
    {
        private Service.connectiondb connectiondb;
        private MySqlConnection connection;


        public void Exclua(long cpf)
        {

            connection = new MySqlConnection();
            connectiondb = new Service.connectiondb();
            connection.ConnectionString = connectiondb.getConnectionString();
            var query = "DELETE FROM nome_tabela WHERE cpf = ?cpf";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("?cpf", cpf);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                connection.Close();
            }
        }

        public void Insira(string nome, long cpf, Endereco endereco, Telefone telefones)
        {
            connection = new MySqlConnection();
            connectiondb = new Service.connectiondb();
            connection.ConnectionString = connectiondb.getConnectionString();
            var query = "INSERT INTO nome_tabela(nome, cpf, endereco, telefones) VALUES (?nome, ?cpf, ?endereco, ?telefones)";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?cpf", cpf);
                cmd.Parameters.AddWithValue("?endereco", endereco);
                cmd.Parameters.AddWithValue("?telefones", telefones);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally 
            {
                connection.Close();
            }
            
        }


        public void Altera(string nome, long cpf, Endereco endereco, Telefone telefones)
        {
            connection = new MySqlConnection();
            connectiondb = new Service.connectiondb();
            connection.ConnectionString = connectiondb.getConnectionString();
            string query = "UPDATE nome_tabela SET nome = ?nome, endereco = ?endereco, telefone = ?telefones WHERE cpf = ?cpf";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?cpf", cpf);
                cmd.Parameters.AddWithValue("?endereco", endereco);
                cmd.Parameters.AddWithValue("?telefones", telefones);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                connection.Close();
            }

        }


        public void Consulte(long cpf)
        {
            connection = new MySqlConnection();
            connectiondb = new Service.connectiondb();
            connection.ConnectionString = connectiondb.getConnectionString();
            string query = "SELECT * FROM nome_tabela WHERE cpf = ?cpf";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("?cpf", cpf);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                connection.Close();
            }

        }

    }
}
