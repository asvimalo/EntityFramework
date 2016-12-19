<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateRented.aspx.cs" Inherits="MediaStoreWebApp.UpdateRented" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                
                <img src="../../Images/movie.JPG" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1><strong>Rent A Movie</strong></h1>
                <div class="col-md-6 col-sm-6">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Movie Name: "></asp:Label></div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Custumer's Name: "></asp:Label></div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Rented To: "></asp:Label></div>
                    
                </div>
                <div class="col-md-6 col-sm-6">
                    <%--<asp:TextBox ID="_txtBoxRentedMovieName" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="_dropDownMovies" runat="server" SelectMethod="GetAllMovies"  DataTextField="MovieName" DataValueField="MovieId">
                    </asp:DropDownList>
                    
                    <asp:DropDownList ID="_dropDownCustomers" runat="server" SelectMethod="GetCustomers"  DataTextField="CustomerName" DataValueField="CustomerID">
                    </asp:DropDownList>
                    
                    <asp:TextBox ID="_txtBoxRentedTo" runat="server"></asp:TextBox>
                    
                    
                </div>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnCreateMovie" Width="100%" runat="server" Cssclass="btn btn-primary" Text="Add Movie To Rent" Font-Bold="True" OnClick="_btnUpdateRentedMovie_Click" />
            </div>
        </div>
    </div>
</asp:Content>
