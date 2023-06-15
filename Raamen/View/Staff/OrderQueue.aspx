<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="Raamen.View.Staff.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Unhandle Order"></asp:Label>

    <br />
    <asp:GridView ID="UnhandleGV" AutoGenerateColumns="true" OnRowCommand="UnhandleGV_RowCommand" runat="server">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="HandleOrder" Text="Handle Order" />
        </Columns>
    </asp:GridView>

    <br />

 
    <asp:Label ID="Label2" runat="server" Text="Handled Order"></asp:Label>
        <asp:GridView ID="HandledGV" runat="server" AutoGenerateColumns="true" CssClass="cart-grid" OnRowCommand="HandledGV_RowCommand">
    </asp:GridView>
 
</asp:Content>
