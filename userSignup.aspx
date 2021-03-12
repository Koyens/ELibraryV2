<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userSignup.aspx.cs" Inherits="ELibrary.userSignup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="p-2">
        <div class="row">
            <div class="col-lg-5 mx-auto">
                <div class="card bg-dark">
                    <div class="card-body">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <img src="imgs/regs.png" width="150px" />
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h2>Member Sign Up</h2>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Full Name</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBoxFullName" placeholder="Full Name" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Date of Birth</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBoxBirthdate" TextMode="Date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <label>Contact Number</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxContactNumber" TextMode="Number" placeholder="Number" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <label>Email Address</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxEmail" TextMode="Email" placeholder="Email@example.com" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <label>State</label>
                                        <div class="form-group">
                                            <asp:DropDownList CssClass="form-control" ID="DropDownListState" runat="server">
                                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                <asp:ListItem Text="Banilad" Value="Banilad"></asp:ListItem>
                                                <asp:ListItem Text="Talamban" Value="Talamban"></asp:ListItem>
                                                <asp:ListItem Text="Bacayan" Value="Bacayan"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>City</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxCity" placeholder="City" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>Zip Code</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxCode" TextMode="Number" placeholder="Code" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <label>Full Address</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxAddress" TextMode="MultiLine" placeholder="Address" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <span class="badge badge-pill badge-primary">Login Credentials</span>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <label>Member ID</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxMemberID" placeholder="ID" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>Password</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxPassword" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>Confirm</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBoxConfirmPassword" placeholder="Re-type Password" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <!-- Button trigger modal -->
                                        <button type="button" class="btn btn-primary btn-block" data-toggle="modal" data-target="#staticBackdrop">
                                            Sign Up
                                        </button>

                                        <!-- Modal -->
                                        <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="staticBackdropLabel">Confirm Signup</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body">
                                                        Do you wish to continue?
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                                                        <asp:Button CssClass="btn btn-primary" ID="ButtonSignUpYes" runat="server" Text="Yes" OnClick="ButtonSignUpYes_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx" class="text-dard text-decoration-none"><< Go Home</a>
            </div>
        </div>
    </section>
</asp:Content>
