<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRentedMovies.aspx.cs" Inherits="MediaStoreWebApp.UserRentedMovies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                <img class="img-responsive" src="../Images/Movies_smaller.jpg" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1><strong>Welcome <asp:Label ID="_lblUserName" runat="server" Text=""></asp:Label></strong></h1>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnReturnToMovies" runat="server" CssClass="btn btn-primary" Text="Return To Movies" Font-Bold="True" Width="100%" OnClick="_btnReturnToMovies_Click" />
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
                                <stong>Title: <%#:Item.Movie.MovieName%></stong>
                                
                            </div>
                            <div>Return: <%#:Item.RentedTo%></div>
                            <div>
                                <asp:CheckBox ID="_checkBoxHired" runat="server"/>
                                <asp:Label ID="_lblHired" runat="server" Text="" ForeColor="Red" ></asp:Label>
                            </div>
                        </caption>
                        <hr />

                        <asp:Button Value="<%#:Item.RentedID%>" ID="_btnReturnMovie" CssClass="btn btn-success" Width="100%" runat="server" Text="Return" Font-Bold="True" OnClick="_btnReturnMovie_Click"/>

                        

                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
