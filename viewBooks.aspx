<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewBooks.aspx.cs" Inherits="ELibrary.viewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="bg-info">
        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="card bg-danger">
                        <div class="card-body">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <h3>Book List</h3>
                                            </center>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <asp:SqlDataSource ID="SqlDataSourceBookList" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString5 %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                        <div class="col">
                                            <asp:GridView CssClass="table table-striped table-bordered table-responsive" ID="GridViewBookList" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSourceBookList">
                                                <Columns>
                                                    <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
                                                    <asp:TemplateField HeaderText="Book Details">
                                                        <ItemTemplate>
                                                            <div class="container-fluid">
                                                                <div class="row">
                                                                    <div class="col-lg-10">
                                                                        <div class="row">
                                                                            <div class="col">
                                                                                <asp:Label CssClass="badge badge-pill badge-danger" ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col">

                                                                                Author -
                                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                                &nbsp;| Language -
                                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                                &nbsp;| Pages -
                                                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("pages") %>'></asp:Label>
                                                                                &nbsp;| Genre -
                                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>

                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col">

                                                                                Publisher -
                                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                                &nbsp;| Date Published -
                                                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                                &nbsp;| Edition -
                                                                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col">

                                                                                Cost -
                                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                                &nbsp;| Actual Stock -
                                                                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                                &nbsp;| Available -
                                                                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Italic="False" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col">

                                                                                Description -
                                                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-2">
                                                                        <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
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
                </div>
            </div>
        </div>
    </section>
</asp:Content>
