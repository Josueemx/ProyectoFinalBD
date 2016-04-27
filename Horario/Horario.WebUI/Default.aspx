<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Horario.WebUI.Default" %>
<%@ Import Namespace="System.Data.OleDb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DataGrid ID="ProfeGrid" runat="server">

    </asp:DataGrid>
    <br />
    <p>aqui abajo deberia estar</p>
    <br />
    <asp:DataList  ID="ProfeGrid2" runat="server">
        <ItemTemplate>
            <%# Eval("Nombre")%>
            <asp:Label id="Text1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Nombre") %>'/> <!-- aqui -->
        </ItemTemplate>
    </asp:DataList>
    </div>
    </form>
</body>
</html>
