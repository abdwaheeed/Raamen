<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="Raamen.View.Staff.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="Label1" runat="server" Text="Update Ramen List"></asp:Label><br /><br />

    <asp:GridView ID="MeatGv" AutoGenerateColumns="true" runat="server" OnRowCommand="MeatGv_RowCommand">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="Label2" runat="server" Text="Meat ID"></asp:Label><br />
    <asp:TextBox ID="meatTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label3" runat="server" Text="Ramen"></asp:Label><br />
    <asp:TextBox ID="ramenTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label4" runat="server" Text="Broth"></asp:Label><br />
    <asp:TextBox ID="brothTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label><br />
    <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Error" runat="server" Text=""></asp:Label><br /><br />

    <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />

</asp:Content>
