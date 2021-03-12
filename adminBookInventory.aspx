<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminBookInventory.aspx.cs" Inherits="ELibrary.adminBookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            function readURL(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('#img-view').attr('src', e.target.result);
                    };

                    reader.readAsDataURL(input.files[0]);
                }
            }

            $(document).ready(function () {
                $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg-dark">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Book Details</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books.png" id="img-view" width="100px" height="130px" />
                                </center>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:FileUpload CssClass="form-control" ID="FileUpload1" onchange="readURL(this);" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" placeholder="ID" ID="TextBoxBookID" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-info" ID="ButtonGo" runat="server" Text="Go" OnClick="ButtonGo_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Book Name" ID="TextBoxBookName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownListLanguage" runat="server">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="Spanish" Value="Spanish"></asp:ListItem>
                                        <asp:ListItem Text="Tagalog" Value="Tagalog"></asp:ListItem>
                                        <asp:ListItem Text="Chinese" Value="Chinese"></asp:ListItem>
                                        <asp:ListItem Text="Japanese" Value="Japanese"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownListPublisherName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-xl-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownListAuthorName" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Date" ID="TextBoxPublishDate" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xl-4">
                                <label>Genre</label>
                                <asp:ListBox CssClass="form-control" ID="ListBoxGenre" Rows="5" runat="server" SelectionMode="Multiple">
                                    <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
                                    <asp:ListItem Text="Adventure" Value="Adventure"></asp:ListItem>
                                    <asp:ListItem Text="Comics" Value="Comics"></asp:ListItem>
                                    <asp:ListItem Text="Romance" Value="Romance"></asp:ListItem>
                                    <asp:ListItem Text="Comedy" Value="Comedy"></asp:ListItem>
                                    <asp:ListItem Text="Horror" Value="Horror"></asp:ListItem>
                                    <asp:ListItem Text="Sci-fi" Value="Sci-fi"></asp:ListItem>
                                </asp:ListBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxEdition" placeholder="Edition" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xl-4">
                                <label>Book Cost</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="TextBoxBookCost" placeholder="Cost Per Unit" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xl-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="TextBoxPages" placeholder="Pages" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="TextBoxActualStock" placeholder="Actual Stock" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xl-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="TextBoxCurrentStock" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xl-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxIssuedBooks" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="TextBoxBookDescription" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <!-- Button trigger modal -->
                                <button type="button" class="btn btn-success btn-block" data-toggle="modal" data-target="#staticBackdrop1">
                                    Add
                                </button>

                                <!-- Modal -->
                                <div class="modal fade" id="staticBackdrop1" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered">
                                        <div class="modal-content">
                                            <div class="modal-header bg-success">
                                                <h5 class="modal-title" id="staticBackdropLabel">Add Confirmation</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                Do you wish to continue?
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                                                <asp:Button CssClass="btn btn-primary" ID="ButtonAddBook" runat="server" Text="Yes" OnClick="ButtonAddBook_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <!-- Button trigger modal -->
                                <button type="button" class="btn btn-primary btn-block" data-toggle="modal" data-target="#staticBackdrop2">
                                    Update</button>

                                <!-- Modal -->
                                <div class="modal fade" id="staticBackdrop2" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered">
                                        <div class="modal-content">
                                            <div class="modal-header bg-primary">
                                                <h5 class="modal-title" id="staticBackdropLabel">Update Confirmation</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                Do you wish to continue?
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                                                <asp:Button CssClass="btn btn-primary" ID="ButtonUpdateBook" runat="server" Text="Yes" OnClick="ButtonUpdateBook_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <!-- Button trigger modal -->
                                <button type="button" class="btn btn-danger btn-block" data-toggle="modal" data-target="#staticBackdrop3">
                                    Delete</button>

                                <!-- Modal -->
                                <div class="modal fade" id="staticBackdrop3" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered">
                                        <div class="modal-content">
                                            <div class="modal-header bg-danger">
                                                <h5 class="modal-title" id="staticBackdropLabel">Delete Confirmation</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                Do you wish to continue?
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                                                <asp:Button CssClass="btn btn-primary" ID="ButtonDeleteYes" runat="server" Text="Yes" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Book Inventory List</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSourceBook" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString5 %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSourceBook">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />
                                        <asp:TemplateField HeaderText="Book Details">
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:Label CssClass="badge badge-pill badge-warning" ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">

                                                                    Author -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre -
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label CssClass="badge badge-pill badge-primary" ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">

                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Published -
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("pages") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">

                                                                    Cost -
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available -
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">

                                                                    Description -
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="ImageBook" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>