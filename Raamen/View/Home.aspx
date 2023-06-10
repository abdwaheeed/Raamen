<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Raamen.View.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <nav style="z-index: 99">
            <% if (Session["user"] == null)%>
            <%{ %>
                <table style="width: 100%; text-align: center;" class="menus">
                <tr>
                    <td style="width: 50%;" class="menus"><a href="/View/Register.aspx" class="menus">Register</a></td>
                    <td style="width: 50%;" class="menus"><a href="/View/Login.aspx" class="menus">Login</a></td>
                </tr>
            </table>
            <%} %>
            <%else if(Session["user"] != null && Raamen.Controller.UserController.isAdmin(Int32.Parse(Session["user"].ToString())))%>
            <%{ %>
                <table style="width: 100%; text-align: center;" class="menus">
                <tr>
                    <td style="width: 17%;" class="menus"><a href="/View/ManageRamen.aspx" class="menus">Manage Ramen</a></td>
                    <td style="width: 17%;" class="menus"><a href="/View/OrderQueue.aspx" class="menus">Order Queue</a></td>
                    <td style="width: 17%;" class="menus"><a href="/View/Profile.aspx" class="menus">Profile</a></td>
                    <td style="width: 17%;" class="menus"><a href="/View/History.aspx" class="menus">History</a></td>
                    <td style="width: 17%;" class="menus"><a href="/View/Report.aspx" class="menus">Report</a></td>
                    <td style="width: 17%;" class="menus"><asp:LinkButton ID="LinkButton3" runat="server" OnClick="Logout">Logout</asp:LinkButton></td>
                </tr>
                </table>
                <asp:Label ID="Label1" runat="server" Text="Role: Admin"></asp:Label>
            <%}%>
            <%else if(Session["user"] != null && Raamen.Controller.UserController.isStaff(Int32.Parse(Session["user"].ToString())))%>
            <%{ %>
                <table style="width: 100%; text-align: center;" class="menus">
                <tr>
                    <td style="width: 20%;" class="menus"><a href="/View/Home.aspx" class="menus">Home</a></td>
                    <td style="width: 20%;" class="menus"><a href="/View/ManageRamen.aspx" class="menus">Manage Ramen</a></td>
                    <td style="width: 20%;" class="menus"><a href="/View/OrderQueue.aspx" class="menus">OrderQueue</a></td>
                    <td style="width: 20%;" class="menus"><a href="/View/Profile.aspx" class="menus">Profile</a></td>
                    <td style="width: 17%;" class="menus"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="Logout">Logout</asp:LinkButton></td>
                </tr>
                </table>
                <asp:Label ID="Label2" runat="server" Text="Role: Staff"></asp:Label>
            <%}%>
            <%else if(Session["user"] != null && Raamen.Controller.UserController.isMember(Int32.Parse(Session["user"].ToString())))%>
            <%{ %>
                <table style="width: 100%; text-align: center;" class="menus">
                <tr>
                    <td style="width: 17%;" class="menus"><a href="/View/OrderRamen.aspx" class="menus">Order Ramen</a></td>
                    <td style="width: 17%;" class="menus"><a href="/View/History.aspx" class="menus">History</a></td>
                    <td style="width: 17%;" class="menus"><a href="/View/Profile.aspx" class="menus">Profile</a></td>
                    <td style="width: 17%;" class="menus"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="Logout">Logout</asp:LinkButton></td>
                </tr>
                </table>
                <asp:Label ID="Label3" runat="server" Text="Role: Member"></asp:Label>
            <%}%>
        </nav>
    </form>
</body>
</html>
