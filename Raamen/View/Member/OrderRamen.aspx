<%@ Page Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="Raamen.View.Member.Ramen" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="RamenUpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="iduser" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Ramen"></asp:Label>
                <asp:GridView ID="RamenGV" AutoGenerateColumns="true" runat="server" CssClass="ramen-grid" OnRowCommand="RamenGV_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="AddToCart" Text="Add to Cart" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="RamenGV" EventName="RowCommand" />
            </Triggers>
        </asp:UpdatePanel>

        <br />

        <asp:UpdatePanel ID="CartUpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label2" runat="server" Text="Cart"></asp:Label>
                    <asp:GridView ID="CartGV" runat="server" AutoGenerateColumns="true" CssClass="cart-grid" OnRowCommand="CartGV_RowCommand">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="RemoveFromCart" Text="Remove" />
                        </Columns>
                    </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="RamenGV" EventName="RowCommand" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:Button ID="ClearBtn" runat="server" Text="Clear All Cart" OnClick="ClearBtn_Click" />
        <asp:Button ID="OrderBtn" runat="server" Text="Order" OnClick="OrderBtn_Click"/>
    </div>
</asp:Content>