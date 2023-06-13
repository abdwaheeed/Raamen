﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="Raamen.View.Staff.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Manage Ramen"></asp:Label><br />

    <asp:GridView ID="raamenView" 
        OnRowDeleting="raamenView_RowDeleting" 
        OnRowEditing="raamenView_RowEditing" 
        AutoGenerateEditButton="true" 
        AutoGenerateDeleteButton="true" 
        runat="server" OnSelectedIndexChanged="raamenView_SelectedIndexChanged">
    </asp:GridView><br />

    <asp:Label ID="Label5" runat="server" Text="Meat ID"></asp:Label><br />
    <asp:TextBox ID="meatTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label2" runat="server" Text="Ramen"></asp:Label><br />
    <asp:TextBox ID="ramenTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label3" runat="server" Text="Broth"></asp:Label><br />
    <asp:TextBox ID="brothTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label><br />
    <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox><br /><br />

    <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click" />

</asp:Content>
