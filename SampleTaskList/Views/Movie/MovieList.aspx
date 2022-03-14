<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="SampleTaskList.Views.Movie.MovieList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-warning">Movie List</h1>
    <div class="list-sec container">
        <%if (Session["alert"] != null && Session["alert-type"] != null )
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
           
             <div class="col-md-5 col-md-offset-1">
                <div class="form-group row">
    <label for="txtSearch" class="searchlabel col-sm-4 col-form-label">Movie Name</label>
    <div class="col-sm-6">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
    </div>
     <div class="col-sm-2">
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
    </div>
                    </div>
                 </div>
              <div class="col-md-5">
             <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning" OnClick="btnClear_Click"/>
                   <asp:Button ID="btnImport" runat="server" Text="Import from Excel File" CssClass="btn btn-danger" OnClick="btnImport_Click"/>
                 
            </div>
  </div>
        <br />
        <div class="row">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="grvMovie" runat="server" CssClass="gvMovie table table-striped table-hover pt-5" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grvMovie_RowDeleting" OnRowUpdating="grvMovie_RowUpdating" AllowPaging="False" PageSize="5" OnPageIndexChanging="grvMovie_PageIndexChanging" ShowHeaderWhenEmpty="true">
                    <Columns>
            <asp:TemplateField ItemStyle-Width="5%">
              <HeaderTemplate>
                  <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
              </ItemTemplate>

<ItemStyle Width="5px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="35%">
              <HeaderTemplate >
                  <asp:Label ID="Label2" runat="server" Text="Label">Movie Name</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("movie"))%>
              </ItemTemplate>

<ItemStyle Width="400px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20%" ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success"></asp:LinkButton>
                    
              </ItemTemplate>
             
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
             
            </asp:TemplateField>
                      <asp:TemplateField ItemStyle-Width="20%" ItemStyle-CssClass="text-center table-options"  HeaderStyle-CssClass="text-center">
                          <ItemTemplate>
                              
               <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="btnDelete"  runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                          </ItemTemplate>

<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
                      </asp:TemplateField>

          </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                    <HeaderStyle BackColor="#6699FF" ForeColor="Black" />
          <%--  <PagerStyle   Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="pagination-ys" BackColor="White" BorderColor="White"/>--%>
                </asp:GridView>
            </div>
        </div>
    </div>
    
    <script type="text/javascript">
    $(function () {
        $("[id=grvMovie]").DataTable(
            {
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
    });
</script>
  </asp:Content>


