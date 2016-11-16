using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace SiteCartorio
{
    public class LerDbacces
    {
        public OleDbConnection criaconexao()
        {
            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\dbclientessite.mdb");
            try
            {
                conexao.Open();
                return conexao;

            }catch(Exception e)
            {
                throw e;

            }


        }

        
    }
}