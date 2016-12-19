<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="MediaStoreWebApp.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" runat="server" href="~/">Media Store</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">

                    <li><a runat="server" href="LoggedAdmin.aspx">Home</a></li>
                    <li><a runat="server" href="Movies.aspx">Movies</a></li>
                    <li><a runat="server" href="Rented.aspx">RentedMovies</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-2 col-sm-2">
                <img class="img-responsive" src="../Images/users.png" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1><strong>Users List</strong> </h1>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnCreateUser" Width="100%" runat="server" CssClass="btn btn-primary" Text="Add" Font-Bold="True" OnClick="_btnCreateUser_Click" />
            </div>
        </div>
    </div>

    <div class="row">

        <asp:ListView ID="_userListView" runat="server" DataKeyNames="CustomerID" ItemType="MovieStore.Models.Customer" SelectMethod="GetAllCustomers">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>

                    </tr>

                </table>

            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td />

            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>

                </tr>

            </GroupTemplate>
            <ItemTemplate>
                <div class="col-md-3 col-sm-3">
                    <div class="thumbnail">

                        <hr />
                        <caption>
                            <div>
                                <stong>ID: </stong>
                                <%#:Item.CustomerID%>
                            </div>
                            <div>Name: <%#:Item.CustomerName%></div>
                            <div>Address: <%#:Item.CustomerAdress%></div>
                            <div>Phone: <%#:Item.CustomerPhone%></div>

                            <asp:ListView ID="_listViewMoviesHired" runat="server" DataKeyNames="MovieId" ItemType="MovieStore.Models.Movie" SelectMethod="GetAllRentedMovies">
                                <EmptyDataTemplate>
                                    <table>
                                        <tr>
                                            <td>No data was returned.</td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                                <EmptyItemTemplate>
                                    <td />
                                </EmptyItemTemplate>
                                <GroupTemplate>
                                    <tr id="itemPlaceholderContainer" runat="server">
                                        <td id="itemPlaceholder" runat="server"></td>
                                    </tr>
                                </GroupTemplate>
                                <ItemTemplate>
                                    <div>
                                        <span>Movies hired: <%#:Item.MovieName%></span>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                            <%--<div>Phone: <%#:Item.RenteredMoviesCustomer%></div>--%>
                            <div>
                                <asp:Label ID="_lblHired" runat="server" Text=""></asp:Label>
                            </div>
                        </caption>
                        <hr />



                        <asp:Button Value="<%#:Item.CustomerID%>" ID="_btnDeleteUser" CssClass="btn btn-danger" Width="32%" runat="server" Text="Delete" OnClick="_btnDeleteUser_Click" />

                        <asp:Button Value="<%#:Item.CustomerID%>" ID="_btnUpdateUser" CssClass="btn btn-success" Width="32%" runat="server" Text="Update" OnClick="_btnUpdateUser_Click" />

                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
