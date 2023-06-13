<%@ Page Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Raamen.View.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav style="z-index: 99">

        <%if(Session["user"] != null && Raamen.Controller.UserController.isAdmin(Int32.Parse(Session["user"].ToString())))%>
        <%{ %>
            <asp:Label ID="Label1" runat="server" Text="Role: Admin"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Customer:"></asp:Label>
            <asp:GridView ID="CustomerGV1" runat="server"></asp:GridView>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Staff: "></asp:Label>
            <asp:GridView ID="StaffGV" runat="server"></asp:GridView>
        <%}%>
        <%else if(Session["user"] != null && Raamen.Controller.UserController.isStaff(Int32.Parse(Session["user"].ToString())))%>
        <%{ %>
            <asp:Label ID="Label2" runat="server" Text="Role: Staff"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Customer:"></asp:Label>
            <asp:GridView ID="CustomerGV2" runat="server"></asp:GridView>
        <%}%>
        <%else if(Session["user"] != null && Raamen.Controller.UserController.isMember(Int32.Parse(Session["user"].ToString())))%>
        <%{ %>
            <asp:Label ID="Label3" runat="server" Text="Role: Member"></asp:Label>
        <%}%>
    </nav>
</asp:Content>
