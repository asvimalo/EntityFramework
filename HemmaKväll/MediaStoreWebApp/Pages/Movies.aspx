<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MediaStoreWebApp.Movies" %>

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
                    <li><a runat="server" href="Users.aspx">Users</a></li>
                    <li><a runat="server" href="Rented.aspx">Rented Movies</a></li>
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
                <h1><strong>Movies</strong> </h1>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnCreateMovie" runat="server" CssClass="btn btn-primary" Text="Add" Font-Bold="True" OnClick="_btnCreateMovie_Click" />
            </div>
        </div>
    </div>

    <div class="row">

        <asp:ListView ID="MovieListView" runat="server" DataKeyNames="MovieId" ItemType="MovieStore.Models.Movie" SelectMethod="GetAllMovies">
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
                                <stong>Title: </stong>
                                <%#:Item.MovieName%>
                            </div>
                            <div>Director: <%#:Item.DirectorName%></div>
                            <div>
                                <%--<asp:Label ID="_lblHired" runat="server"  Text=""  OnLoad="_CreateLabel_Load" ></asp:Label>--%>
                                <asp:placeholder id="PlaceHolderLabel" runat="server" ></asp:placeholder>
                                <%--<asp:CheckBox ID="_checkBoxHired" runat="server"/>--%>
                                <%--<asp:Label ID="_lblHired" runat="server" Text="" OnLoad="OnLayoutCreated_Load" ForeColor="Red"></asp:Label>--%>
                                <%--<asp:Label ID="_lblAvailable" runat="server" Text="<%#:Item.RenteredMovies.Where(x => x.RentedTo != null).Select(y => y.MovieID == Item.MovieId)%>" OnLoad="_lblHired_Load" ForeColor="Red" ></asp:Label>--%>
                            </div>
                        </caption>
                        <hr />

                        <asp:Button Value="<%#:Item.MovieId%>" ID="_btnHyreMovie" CssClass="btn btn-primary" Width="32%" runat="server" Text="Hire" Font-Bold="True" OnClick="_btnHyreMovie_Click" />

                        <asp:Button Value="<%#:Item.MovieId%>" ID="_btnDeleteMovie" CssClass="btn btn-danger" Width="32%" runat="server" Text="Delete" Font-Bold="True" OnClick="_btnDeleteMovie_Click" />

                        <asp:Button Value="<%#:Item.MovieId%>" ID="_btnUpdateMovie" CssClass="btn btn-success" Width="32%" runat="server" Text="Update" Font-Bold="True" OnClick="_btnUpdateMovie_Click" />

                    </div>
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>
