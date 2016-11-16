
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteCartorio
{
    public class ConexaoDb
    {

        public SqlConnection getConexao()
        {
            SqlConnection conexao = new SqlConnection(@"Server =servidor\SQLEXPRESS; Database = BDSITE; User Id = sa;Password = 12345qaz@;");



            conexao.Open();
           
             
            
            return conexao;


        }

        public SqlCommand getComando(SqlConnection conexao)
        {
            SqlCommand comando = conexao.CreateCommand();
            return comando;

        }

        public SqlDataReader getReader(SqlCommand comando)
        {
            SqlDataReader reader = comando.ExecuteReader();
            return reader;

        }
    }
}