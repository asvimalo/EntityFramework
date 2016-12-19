<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoggedAdmin.aspx.cs" Inherits="MediaStoreWebApp.LoggedAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                <img class="img-responsive" src="../Images/Admin.jpg" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1 class="text-center"><strong>Welcome
                    <asp:Label ID="_lblUserAdmin" runat="server" Text=""></asp:Label></strong> </h1>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnLogout" runat="server" Width="100%" CssClass="btn btn-danger" Text="Logout" Font-Bold="True" OnClick="_btnLogout_Click" />
            </div>
        </div>
    </div>
    <div class="row">
        
       <%-- <div class="col-md-6 col-sm-6">--%>
            <a href="Movies.aspx">
                <div class="thumbnail col-md-4 col-sm-4">
                    <h1 class="text-center"><strong>Movies List</strong> </h1>
                    <img src="../Images/Movies_smaller.jpg" />
                </div>
            </a>
            <a href="Rented.aspx">
                <div class="thumbnail col-md-4 col-sm-4">
                    <h1 class="text-center"><strong>Rented Movies List</strong> </h1>
                    <img src="../Images/RentedMovie.jpg" />
                </div>
            </a>

            <a href="Users.aspx">
                <div class="thumbnail col-md-4 col-sm-4">
                    <h1 class="text-center"><strong>Users List</strong> </h1>
                    <img src="../Images/users.png" />
                </div>
            </a>
        <%--</div>--%>
        <%--<div class="col-md-3 col-sm-3">--%>
            <%--<asp:Button ID="_btnCreateUser" Width="100%" runat="server" CssClass="btn btn-primary" Text="Add" Font-Bold="True" OnClick="_btnCreateUser_Click" />--%>
       <%-- </div>--%>
    </div>

</asp:Content>
