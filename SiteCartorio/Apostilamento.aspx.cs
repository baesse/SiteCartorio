using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteCartorio
{
    public partial class Apostilamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          


        }
       

       


        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean cadastrado = false;

            string protocolo = TextBox1.Text;
            string data = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            

                if (TextBox1.Text == "")
                {
                    Response.Write("<script>alert('Favor digitar alguma protocolo');</script>");
                }
                else
                {
                if (verdigitoano(protocolo))
                {


                    ConexaoDb gerenciadb = new ConexaoDb();
                    SqlConnection conexaosql = gerenciadb.getConexao();
                    SqlCommand comandosql = gerenciadb.getComando(conexaosql);
                    comandosql.CommandType = System.Data.CommandType.Text;

                    comandosql.CommandText = "SELECT PROTOCOLO FROM PROTOCOLOHAIA WHERE  @PROTOCOLO = PROTOCOLO";
                    comandosql.Parameters.Add("@PROTOCOLO", protocolo + "/" + DateTime.Now.Year);
                    SqlDataReader reader = gerenciadb.getReader(comandosql);


                    while (reader.Read())
                    {
                        protocolo = protocolo + "/" + DateTime.Now.Year;

                        if (protocolo.Equals(reader.GetString(0)))
                        {

                            Response.Write("<script>alert('Protocolo já cadastrado');</script>");
                            cadastrado = true;
                            break;


                        }
                    }



                    if (cadastrado == false)
                    {
                        Boolean sedex = false;
                        int simsedex= 0;


                        if (CheckBox1.Checked)
                        {
                            sedex = true;
                            simsedex = 1;

                        }

                        reader.Close();
                        comandosql.Parameters.Clear();

                        comandosql.CommandText = "INSERT INTO PROTOCOLOHAIA (PROTOCOLO,DATALIBERACAO,sedex)VALUES(@PROTOCOLO,@DATALIBERACAO,@sedex)";
                        comandosql.Parameters.Add("@PROTOCOLO", protocolo + "/" + DateTime.Now.Year);
                        comandosql.Parameters.Add("@DATALIBERACAO", data);
                        comandosql.Parameters.Add("@sedex", simsedex);
                        comandosql.ExecuteNonQuery();
                        TextBox1.Text = "";

                        Label1.Focus();
                        GridView1.DataBind();

                    }
                }
            }
        }

        


        public Boolean verdigitoano(string busca)
        {
            for(int i = 0; i < busca.Length; i++)
            {
                if (busca[i]=='/')
                {

                    Response.Write("<script>alert('Favor não digitar o ano');</script>");
                    return false;

                }

            }
            return true;

        }
    }
}