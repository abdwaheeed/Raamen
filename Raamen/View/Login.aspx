<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Raamen.View.Guest.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox> 
            <br />

            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="PasswordTxt" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Error" runat="server" Text=""></asp:Label>
            <br />
            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me" Width="100%" />
            <br />
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
        </div>
    </form>
</body>
</html>
