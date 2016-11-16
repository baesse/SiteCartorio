<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apostilamento.aspx.cs" Inherits="SiteCartorio.Apostilamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Protocolo:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Gravar" OnClick="Button1_Click" />
        <br />

        <asp:Label ID="Label2" runat="server" Text="Sedex:"></asp:Label>
        <asp:CheckBox ID="CheckBox1" runat="server" />
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="PROTOCOLO" HeaderText="PROTOCOLO" SortExpression="PROTOCOLO" />
                <asp:BoundField DataField="DATALIBERACAO" HeaderText="DATALIBERACAO" SortExpression="DATALIBERACAO" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BDSITEConnectionString2 %>" SelectCommand="SELECT [PROTOCOLO], [DATALIBERACAO] FROM [PROTOCOLOHAIA]"></asp:SqlDataSource>
    </form>
</body>
</html>
