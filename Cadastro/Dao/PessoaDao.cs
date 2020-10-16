using Cadastro.model;
using System;
using System.Data;
using System.Data.OleDb;

namespace Cadastro.Dao
{
    class PessoaDao
    {

        public OleDbConnection obterConexao()
        {
            OleDbConnection conn = null;

            string connectionString = "Server = localhost; Database = cadastro; Uid = root; Pwd = ";

            conn = new OleDbConnection(connectionString);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void fecharConexao(OleDbConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public bool Exclua(long cpf)
        {
            string query = "DELETE FROM nome_table WHERE p = '" + cpf + "'";
            OleDbDataReader dataReader = null;
            OleDbConnection dbConnection = null;

            try
            {
                dbConnection = obterConexao();

                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    return true;
                }

                fecharConexao(dbConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;


        }

        public bool Insira(string nome, long cpf, Endereco endereco, Telefone telefones)
        {
            string query = "INSERT INTO nome_tabela(nome, cpf, endereco, telefones) VALUES ('" + nome + "', '" + endereco + "', '" + cpf + "', '" + telefones + "')";
            OleDbDataReader dataReader = null;
            OleDbConnection dbConnection = null;

            try
            {
                dbConnection = obterConexao();

                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    return true;
                }

                fecharConexao(dbConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }


        public bool Altera(string nome, long cpf, Endereco endereco, Telefone telefones)
        {
            string query = "UPDATE nome_tabela SET nome = " + nome + ", endereco = " + endereco + ", telefones = " + telefones + " WHERE cpf =  '" + cpf + "'";
            OleDbDataReader dataReader = null;
            OleDbConnection dbConnection = null;
            try
            {
                dbConnection = obterConexao();

                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    return true;
                }

                fecharConexao(dbConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;

        }


        public bool Consulte(long cpf)
        {
            string query = "SELECT * FROM nome_tabela WHERE cpf = '" + cpf + "'";
            OleDbDataReader dataReader = null;
            OleDbConnection dbConnection = null;
            try
            {
                dbConnection = obterConexao();

                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                dataReader = dbCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        return true;
                    }
                }

                dataReader.Close();
                fecharConexao(dbConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;

        }

    }
}
