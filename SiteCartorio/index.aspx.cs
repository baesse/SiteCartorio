
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SiteCartorio
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CultureInfo newCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = newCulture;

            manipularPagina(0);

            lblemolumentos.Text = "";
            lblitbi.Text = "";
            lblrecompe.Text = "";
            lblregistro.Text = "";
            lblsubtotal.Text = "";
            lbltotal.Text = "";
            lbltxfisc.Text = "";



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string valor = txtvalor.Text;
            decimal valornum = 0;



            try
            {




                valor = Regex.Replace(valor, "[\\(\\)\\-\\ ]", "");


                valornum = Convert.ToDecimal(valor);

                if (valor == "" || valornum < 0)
                {
                    Response.Write("<script>alert('Valor invalido');</script>");
                }
                else
                {



                    lblemolumentos.Text = "";
                    lblitbi.Text = "";
                    lblrecompe.Text = "";
                    lblregistro.Text = "";
                    lblsubtotal.Text = "";
                    lbltotal.Text = "";
                    lbltxfisc.Text = "";



                    ConexaoDb gerenciabd = new ConexaoDb();
                    SqlConnection conexao = gerenciabd.getConexao();
                    SqlCommand comando = gerenciabd.getComando(conexao);
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "select  VALORMINIMO,VALORMAXIMO,RECOMPE,EMOLUMENTOS,TAXAFISC,TOTALVALORNOTAS from VALORESIMOVEIS where  @VALORBUSCA BETWEEN VALORMINIMO AND VALORMAXIMO";
                    comando.Parameters.Add("@VALORBUSCA", valornum);
                    SqlDataReader reader = gerenciabd.getReader(comando);
                    manipularPagina(1);

                    lblemolumentos.Text = "Emolumentos:R$ ";
                    lblrecompe.Text = "Recompe: R$ ";
                    lbltxfisc.Text = "Taxa de fiscalização: R$ ";
                    lblsubtotal.Text = "Sub-Total: R$ ";
                    lblitbi.Text = "ITBI: R$ ";
                    lblregistro.Text = "Valor do registro: R$ ";
                    lbltotal.Text = "Valor Total: R$ ";

                    while (reader.Read())
                    {


                        lblemolumentos.Text = lblemolumentos.Text + reader.GetDecimal(3);
                        lblrecompe.Text = lblrecompe.Text + reader.GetDecimal(2);
                        lbltxfisc.Text = lbltxfisc.Text + reader.GetDecimal(4);
                        lblsubtotal.Text = lblsubtotal.Text + reader.GetDecimal(5);
                        lblregistro.Text = lblregistro.Text + Convert.ToString(reader.GetDecimal(5) + 55);
                        lblitbi.Text = lblitbi.Text + (Convert.ToInt32(valor) * 0.03);

                        lbltotal.Text = lbltotal.Text + Convert.ToString(reader.GetDecimal(5) * 3 / 100 + reader.GetDecimal(5) + reader.GetDecimal(5) + 55).Substring(0, 7);







                    }



                }

            }
            catch (Exception)
            {

             
                Response.Write("<script>alert('Valor invalido');</script>");

            }



           

          
        }


        public void manipularPagina(int definir)
        {
            if (definir == 0)
            {
                lblemolumentos.Visible = false;
                lblitbi.Visible = false;

                lblregistro.Visible = false;
                lblsubtotal.Visible = false;
                lbltotal.Visible = false;
                lbltxfisc.Visible = false;
                lblemolumentos.Visible = false;
                lblrecompe.Visible = false;




            }
            else
            {
                lblemolumentos.Visible = true;
                lblitbi.Visible = true;

                lblregistro.Visible = true;
                lblsubtotal.Visible = true;
                lbltotal.Visible = true;
                lbltxfisc.Visible = true;
                lblemolumentos.Visible = true;
                lblrecompe.Visible = true;


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label20.Text = "";



            string protocolo = TextBox2.Text + "/" + DateTime.Now.Year;

            Boolean achei = false;
            Boolean existe = false;




            ConexaoDb gerenciabd = new ConexaoDb();
            SqlConnection conexao = gerenciabd.getConexao();
            SqlCommand comando = gerenciabd.getComando(conexao);
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select  PROTOCOLO,DATALIBERACAO from PROTOCOLOHAIA where  @PROTOCOLO = PROTOCOLO";
            comando.Parameters.Add("@PROTOCOLO", protocolo);
            SqlDataReader reader = gerenciabd.getReader(comando);


            while (reader.Read())
            {
                if (protocolo.Equals((reader.GetString(0))))
                {
                    Label20.ForeColor = System.Drawing.Color.Red;




                    Label20.Text = "Protocolo: Os serviços referente ao protocolo informado encontra-se disponível desde o dia " + reader.GetString(1);
                    /*
                    if (reader.GetInt32(2) == 1)
                    {
                        Label20.Text = Label20.Text + ". O apostilamento foi solicitado via correios e será postado na agência dentro do prazo estipulado.";

                    }
                    */

                    achei = true;
                   

                    existe = true;
                    break;

                }

              

            }
            if (!existe)
            {
                Response.Write("<script>alert('Protocolo invalido');</script>");

            }
            else if (achei == false) {
                Label20.ForeColor = System.Drawing.Color.Red;
                Label20.Text = "Protocolo: O protocolo ainda não foi finalizado";

            }
        }


    



        }
    }
