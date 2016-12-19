<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MediaStoreWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                <img class="img-responsive" src="Images/Movies_smaller.jpg" />
            </div>
            <div class="col-md-6 col-sm-6">
                
                <h1><strong>Movie Store</strong> </h1>
                <div><strong>Enter username: </strong></div>
                    
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:TextBox ID="_txtBoxUser" Width="100%" runat="server"></asp:TextBox>
                <asp:Button ID="_btnLogUser" Width="100%" runat="server" CssClass="btn btn-primary" Text="LogIn" Font-Bold="True" OnClick="_btnLogUser_Click" />
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
                        <img src="Images/movie.JPG" />
                        <hr />
                        <caption>
                            <div>
                                <stong>Title: </stong>
                                <%#:Item.MovieName%>
                            </div>
                            <div>Director: <%#:Item.DirectorName%></div>
                            <div>
                                <asp:Label ID="_lblHired" runat="server" Text=""></asp:Label>
                            </div>
                        </caption>
                        <hr />

                        <%--<asp:Button Value="<%#:Item.MovieId%>" ID="_btnHyreMovie" CssClass="btn btn-primary" Width="32%" runat="server" Text="Hyre" Font-Bold="True" OnClick="_btnHyreMovie_Click"/>

                        <asp:Button Value="<%#:Item.MovieId%>" ID="_btnDeleteMovie" CssClass="btn btn-danger" Width="32%" runat="server" Text="Delete" Font-Bold="True" OnClick="_btnDeleteMovie_Click"/>

                        <asp:Button Value="<%#:Item.MovieId%>" ID="_btnUpdateMovie" CssClass="btn btn-success" Width="32%" runat="server" Text="Update" Font-Bold="True" OnClick="_btnUpdateMovie_Click"/>--%>

                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
