<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Raamen.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label><br />
    <asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label><br />
    <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
    <asp:RadioButtonList ID="GenderButtons" runat="server" OnSelectedIndexChanged="GenderButtons_SelectedIndexChanged">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:RadioButtonList><br />

    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label><br />
    <asp:TextBox ID="passwordTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Error" runat="server" Text=""></asp:Label><br /><br />

    <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />

</asp:Content>
