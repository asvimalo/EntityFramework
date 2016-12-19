<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rented.aspx.cs" Inherits="MediaStoreWebApp.Rented" %>
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
                    <li><a runat="server" href="Users.aspx">Users</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                <img class="img-responsive" src="../Images/Movies_smaller.jpg" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1><strong>Rented Movies</strong> </h1>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnAddRent" runat="server" Width="100%" CssClass="btn btn-primary" Text="Add Movie To Rent" Font-Bold="True" OnClick="_btnAddRent_Click" />
            </div>
        </div>
    </div>

    <div class="row">

        <asp:ListView ID="RentedListView" runat="server" DataKeyNames="RentedID" ItemType="MovieStore.Models.RentedMovies" SelectMethod="GetAllRentedMovies">
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
                        <img src="../Images/movie.JPG" />
                        <hr />
                        <caption>
                            <div>
                                <stong>Rented ID: </stong>
                                <%#:Item.RentedID%>
                            </div>
                            <div>Movie's Name: <%#:Item.Movie.MovieName%></div>
                            <div>Customer's Name: <%#:Item.Customer.CustomerName%></div>
                            <div>Rented To: <%#:Item.RentedTo%></div>
                            <div>
                                <asp:CheckBox ID="_checkBoxHired" runat="server"/>
                                <asp:Label ID="_lblHired" runat="server" Text="" ForeColor="Red" ></asp:Label>
                            </div>
                        </caption>
                        <hr />

                        <%--<asp:Button Value="<%#:Item.RentedID%>" ID="_btnRentMovie" CssClass="btn btn-primary" Width="32%" runat="server" Text="Rent" Font-Bold="True" OnClick="_btnRentMovie_Click"/>--%>

                        <asp:Button Value="<%#:Item.RentedID%>" ID="_btnDeleteRentMovie" CssClass="btn btn-danger" Width="32%" runat="server" Text="Delete" Font-Bold="True" OnClick="_btnDeleteRentMovie_Click"/>

                        <asp:Button Value="<%#:Item.RentedID%>" ID="_btnUpdateRentMovie" CssClass="btn btn-success" Width="32%" runat="server" Text="Update" Font-Bold="True" OnClick="_btnUpdateRentMovie_Click"/>

                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
