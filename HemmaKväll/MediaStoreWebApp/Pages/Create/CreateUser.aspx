<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="MediaStoreWebApp.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3 col-sm-3">
                
                <img src="../../Images/movie.JPG" />
            </div>
            <div class="col-md-6 col-sm-6">
                <h1><strong>Add User</strong></h1>
                <div class="col-md-6 col-sm-6">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label></div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Address: "></asp:Label></div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Phone: "></asp:Label></div>
                    
                </div>
                <div class="col-md-6 col-sm-6">
                    <asp:TextBox ID="_txtBoxUserName" runat="server"></asp:TextBox>
                    <asp:TextBox ID="_txtBoxUserAddress" runat="server"></asp:TextBox>
                    <asp:TextBox ID="_txtBoxPhone" runat="server"></asp:TextBox>
                    
                </div>
            </div>
            <div class="col-md-3 col-sm-3">
                <asp:Button ID="_btnCreateUser" runat="server" Cssclass="btn btn-primary" Text="Add User" Font-Bold="True" OnClick="_btnCreateUser_Click" />
            </div>
        </div>
    </div>
</asp:Content>
