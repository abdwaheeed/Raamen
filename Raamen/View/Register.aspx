<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Raamen.View.Guest.Register" %>

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


            <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox> 
            <br />


            <asp:Label ID="GenderLabel" runat="server" Text="Gender: "></asp:Label>
            <asp:RadioButtonList ID="GenderButtons" runat="server" OnSelectedIndexChanged="GenderButtons_SelectedIndexChanged">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>


            <br />

            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="PasswordTxt" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label4" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="ConfirmPasswordTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Error" runat="server" Text=""></asp:Label>

            <br />
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click"/>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Already have an account?"></asp:Label>
            <a href="Login.aspx">Login</a>
        </div>
    </form>
</body>
</html>
