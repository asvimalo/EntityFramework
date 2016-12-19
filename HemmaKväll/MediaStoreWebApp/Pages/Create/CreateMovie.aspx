<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateMovie.aspx.cs" Inherits="MediaStoreWebApp.CreateMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                
                <img src="../../Images/movie.JPG" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1><strong>Add Movie</strong></h1>
                <div class="col-md-6 col-sm-6">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Title: "></asp:Label></div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Release Year: "></asp:Label></div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Director: "></asp:Label></div>
                    <asp:Label ID="Label4" runat="server" Text="Gender: "></asp:Label>
                </div>
                <div class="col-md-6 col-sm-6">
                    <asp:TextBox ID="_txtBoxMovieName" runat="server"></asp:TextBox>
                    <asp:TextBox ID="_txtBoxReleaseYear" runat="server"></asp:TextBox>
                    <asp:TextBox ID="_txtBoxDirector" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="_dropDownGender" runat="server">
                        <asp:ListItem Text="Genre" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Porn" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Action" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Fight" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Animation" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Comedie" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Drama" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Romantic" Value="7"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnCreateMovie" runat="server" Cssclass="btn btn-primary" Text="Add Movie" Font-Bold="True" OnClick="_btnCreateMovie_Click" />
            </div>
        </div>
    </div>
</asp:Content>
