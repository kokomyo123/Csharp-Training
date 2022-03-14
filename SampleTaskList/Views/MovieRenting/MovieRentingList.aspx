<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieRentingList.aspx.cs" Inherits="SampleTaskList.Views.MovieRenting.MovieRentingList" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 class="text-center text-warning">MovieRenting List</h1>
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
     <label for="txtSearch" class="searchlabel col-sm-4 col-form-label">Customer Name</label>
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
                <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn btn-danger" OnClick="btnExport_Click"/> 
                <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" CssClass="btn btn-info" OnClick="btnSendMail_Click"/>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-md-9 col-md-offset-1">
                <asp:GridView ID="grvMovieRent" runat="server" CssClass="gvMovierent table table-striped table-hover pt-5" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grvMovieRent_RowDeleting" OnRowUpdating="grvMovieRent_RowUpdating"  OnPageIndexChanging="grvMovieRent_PageIndexChanging" ShowHeaderWhenEmpty="True" PageSize="5">
                    <Columns>
            <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="5px" />
            </asp:TemplateField>
            <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label2" runat="server" Text="Label">Salutation</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("salutation"))%>
              </ItemTemplate>
                <ItemStyle Width="5px" />
            </asp:TemplateField>
              <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label3" runat="server" Text="Label">Customer Name</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("Name"))%>
              </ItemTemplate>
                  <ItemStyle Width="150px" />
            </asp:TemplateField>
               <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label4" runat="server" Text="Label">Address</asp:Label> 
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("address"))%>
              </ItemTemplate>
                   <ItemStyle Width="200px" />
            </asp:TemplateField>
             <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label5" runat="server" Text="Label">Movie Name</asp:Label>  
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("movie"))%>
              </ItemTemplate>
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="50px" ItemStyle-CssClass="text-center table-options"  HeaderStyle-CssClass="text-center">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success"></asp:LinkButton>
                    
              </ItemTemplate>
             
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
             
            </asp:TemplateField>
                        
               <asp:TemplateField ItemStyle-Width="50px" ItemStyle-CssClass="text-center table-options"  HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                
               <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                            </ItemTemplate>

<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
                        </asp:TemplateField>
          </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                     <HeaderStyle BackColor="#6699FF" />
                     <PagerSettings FirstPageText="first" LastPageText="last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                     <PagerStyle Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination-ys" BackColor="White" BorderColor="White"/>
                   
 </asp:GridView>  
            </div>
        </div>
    </div>
</asp:Content>
