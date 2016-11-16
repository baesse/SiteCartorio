<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SiteCartorio.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
     <title>Cartório Jaguarão</title>
    
    
        <link rel="stylesheet" href="CSS/css_home.css">
     <style type="text/css">
         .tabela{
             
             position:relative;
             left:75%;
             top:13px;
             width:24%;
             right:-451px;
             height: 200px;
         }
         .letras{
             font:bold;

         }
         .labels{

             position:relative;
             left:10px;
             top:10px;
             width:212px;
             right:-742px;
             height: 217px;
             
          
             
         }
         .tabelaprotocolo{
             position:absolute;
             top:250px;
             width:30%;
             left: 18%;
             
         }
       
         .auto-style1 {
             height: 36px;
         }
       
     </style>
  </head>
<body>
    <form id="form1" runat="server">
        <header>

        
     <div id="wrapper">
  <div class="join">Cartório Jaguarão</div>
      
          <div class="clr"></div>
                    <div class="clr"><hr /></div>

                    <ul>
  <li><a href="Serviços">Inicio</a></li>
 
  
</ul>

         

        
         <table   cellspacing="10"  class="tabela" cellpadding="0">
        <tbody><tr>
          
            
           
          <td class="Tahoma16_bold_cian"    style ="padding-left:10px;"><br /> Digite o valor do imóvel:</td>
                
        </tr>
        <tr>
          <td style="padding-left:10px;  padding-bottom:10px;" class="Tahoma16_bold_cian">R$
               <asp:TextBox ID="txtvalor"  runat="server" Height="16px" Width="100px"></asp:TextBox>
                </td>
        </tr>
        <tr>
          <td class="Tahoma14_normal_cinza" style="padding-left:10px"; >  Ex.: 1000,00</td>
        </tr>
        <tr>
             
          <td style="padding-left:10px; padding-right:10px;">
              <asp:Button ID="Button1" runat="server" Text="Consultar" OnClick="Button2_Click"  />
            </td>            
          
                </tr>

            
             <tr>
             <td>
                4<asp:Label ID="lblemolumentos" runat="server"  class="labels" Text="Emolumentos:R$ " Font-Size="Small"></asp:Label>
            </td>
                 </tr>
         
           
                
                </tr>
                   <td>

                 <asp:Label ID="lblrecompe" runat="server"  class="labels"  Text="Recompe: R$ " Font-Size="Small" ></asp:Label>
                

            </td>
                <tr>
                <td>

                <asp:Label ID="lbltxfisc" runat="server" class="labels"  Text="Taxa de fiscalização: R$" Font-Size="Small"></asp:Label>
            </td>
            
               <td>

</tr>
                
            <tr>
                <td>
                 <asp:Label ID="lblsubtotal" runat="server" class="labels" Text="Sub-Total: R$ " Font-Size="Small"></asp:Label>
                    
            </td>
                 </tr>
            <tr>
            <td>
               
                 <asp:Label ID="lblitbi" runat="server" class="labels" Text="ITBI: R$ " Font-Size="Small"></asp:Label>
                   
            </td>
                </tr>
            <td>
                


                 <asp:Label ID="lblregistro" runat="server" class="labels"  Text="Registro de imovel: R$" Font-Size="Small"></asp:Label>
                   
            </td>
            
            
            <td>
                
           <tr>
               <td>
            <asp:Label ID="lbltotal" runat="server"  class="labels"  Text="TOTAL: R$ " Font-Bold="true" Font-Size="Small"></asp:Label>
                
                </td>
       
            </tr>
      
                  </div>
  
      </tbody>
            </table>



             <table   cellspacing="10" class="tabelaprotocolo" cellpadding="0">
        <tbody><tr>
          
            
           
          <td class="Tahoma16_bold_cian"    style ="padding-left:10px;"><br /> Digite o Protocolo:</td>
                
        </tr>
        <tr>
          <td style="padding-left:10px; padding-top:10px; padding-bottom:10px;" class="Tahoma16_bold_cian">
               <asp:TextBox ID="TextBox2"  runat="server" Height="16px" Width="100px"></asp:TextBox>
                </td>
        </tr>
       
        <tr>
             
          <td style="padding-left:10px; padding-right:10px;" class="auto-style1">
              <asp:Button ID="Button2" runat="server" Text="Consultar" OnClick="Button2_Click"  />
            </td>            
          
                </tr>
            <td>
             <asp:Label ID="Label20" runat="server"  class="labels"  Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
                         
  
      </tbody>
            </table>

        

             

<div class="clr"></div>
</header>
  <div class="clr"><hr />

          
     


         </div>



<div class="dados">

</div>

<div class="informacoes">


    <p></p>
    <p></p>
    <p></p>
    <p></p>





</div>

                     
                     <div class="content"> 
           <div class="clr"></div>
  <div class="clr">
      <hr /></div>


</div> 

</div>
    </form>
</body>
</html>
