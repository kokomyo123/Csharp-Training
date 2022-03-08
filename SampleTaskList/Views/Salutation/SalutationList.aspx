<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="SalutationList.aspx.cs" Inherits="SampleTaskList.Views.Salutation.SalutationCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-warning">Salutation List</h1>
    <div class="list-sec container">
        <%if (Session["alert"] != null && Session["alert-type"] != null)
            {
                Lblalert.Visible = true;
                Lblalert.Text = Session["alert"].ToString();
                string type = Session["alert-type"].ToString();
        %>
        <div class="AlertMessage" id="AlertMsg">
            <div class="row">
                <div class="col-md-6 col-md-offset-2">
                    <div class="alert alert-<% Response.Write(type); %> alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:Label ID="Lblalert" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <%
                Session.Remove("alert");
                Session.Remove("alert-type");
            } %>
        <div class="row">

            <div class="col-md-5 col-md-offset-3">
                <div class="form-group row">
                    <label for="txtSearch" class="col-sm-4 col-form-label text-info">Salutation Name</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            </div>
        </div>

        <br />
        <div class="row">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="grvSalutation" runat="server" CssClass="table table-striped table-hover pt-5" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grvSalutation_RowDeleting" OnRowUpdating="grvSalutation_RowUpdating" AllowPaging="True" OnPageIndexChanging="grvSalutation_PageIndexChanging" PageSize="5" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="10px">
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                            <HeaderStyle ForeColor="Black" />

                            <ItemStyle Width="5px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px">
                            <HeaderTemplate>
                                <asp:Label ID="Label2" runat="server" Text="Label">Salutation</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("salutation"))%>
                            </ItemTemplate>
                            <HeaderStyle ForeColor="Black" />

                            <ItemStyle Width="400px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success"></asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center"></HeaderStyle>

                            <ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center"></HeaderStyle>

                            <ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    <FooterStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#6699FF" />
                    <PagerSettings PageButtonCount="3" />
                    <PagerStyle Font-Size="Large" VerticalAlign="Middle" CssClass="pagination-ys" HorizontalAlign="Center" BackColor="White" BorderColor="White" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>