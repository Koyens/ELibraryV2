<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="ELibrary.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg-secondary p-2">
        <div class="row">
            <div class="col-md-3 mx-auto">
                <div class="card bg-success">
                    <div class="card-body">
                        <div class="card bg-info">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <img src="imgs/admins.png" width="150px" />
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h2>Admin Login</h2>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <label>Admin ID</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBoxAdminID" placeholder="ID" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <label>Password</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBoxAdminPassword" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button CssClass="btn btn-warning btn-block btn-lg" ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx" class="text-dark text-decoration-none"><< Go Home</a>
            </div>
        </div>
    </section>
</asp:Content>
