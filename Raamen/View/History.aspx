<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Raamen.View.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="HistoryGV" AutoGenerateColumns="true" runat="server" OnRowCommand="HistoryGV_RowCommand">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Detail" Text="View Detail" />
        </Columns>
    </asp:GridView>
</asp:Content>
