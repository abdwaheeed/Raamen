<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="Raamen.View.Staff.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Unhandle Order"></asp:Label>

    <asp:Label ID="rowid" runat="server" Text=""></asp:Label>
    <asp:Label ID="userid" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="UnhandleGV" AutoGenerateColumns="true" OnRowCommand="UnhandleGV_RowCommand" runat="server">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="HandleOrder" Text="Handle Order" />
        </Columns>
    </asp:GridView>
</asp:Content>
