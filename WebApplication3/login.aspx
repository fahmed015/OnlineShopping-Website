<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Username" ForeColor="#666666"></asp:Label>
        <br />
        <asp:TextBox ID="lusername" runat="server" BorderColor="#0099FF"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password" ForeColor="#666666"></asp:Label>
        <br />
        <asp:TextBox ID="lpass" runat="server" BorderColor="#0099FF"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="blogin" runat="server" OnClick="userLogin" Text="Login" BackColor="White" ForeColor="Maroon" />
        <p>
            <asp:HyperLink ID="lregister" runat="server" NavigateUrl="~/mainRegister.aspx">Don&#39;t have an account ? </asp:HyperLink>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
