<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoggedUser.aspx.cs" Inherits="MediaStoreWebApp.LoggedUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                <img class="img-responsive" src="../Images/Movies_smaller.jpg" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1 class="text-center"><strong>Movies</strong> </h1>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnCheckRentedMovies" runat="server" Width="100%" CssClass="btn btn-primary" Text="Check Rented Movies" Font-Bold="True" OnClick="_btnCheckRentedMovies_Click" />
                <asp:Button ID="_btnLogout" runat="server" Width="100%" CssClass="btn btn-danger" Text="Logout" Font-Bold="True" OnClick="_btnLogout_Click" />
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
                                <asp:CheckBox ID="_checkBoxHired" runat="server"/>
                                <asp:Label ID="_lblHired" runat="server" Text="" ForeColor="Red" ></asp:Label>
                            </div>
                        </caption>
                        <hr />

                        <asp:Button Value="<%#:Item.MovieId%>" ID="_btnHyreMovie" CssClass="btn btn-primary" Width="32%" runat="server" Text="Hire" Font-Bold="True" OnClick="_btnHyreMovie_Click"/>

                        <%--<asp:Button Value="<%#:Item.MovieId%>" ID="_btnReturnMovie" CssClass="btn btn-success" Width="32%" runat="server" Text="Return" Font-Bold="True" OnClick="_btnReturnMovie_Click"/>--%>

                        <%--<asp:Button Value="<%#:Item.MovieId%>" ID="_btnUpdateMovie" CssClass="btn btn-success" Width="32%" runat="server" Text="Update" Font-Bold="True" OnClick="_btnUpdateMovie_Click"/>--%>

                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
