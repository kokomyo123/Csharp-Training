<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Tutorial8.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <style>
        .page a, .page span {
            display: block;
            float: left;
            padding: 0.3em 0.5em;
            margin-right: 5px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="margin-top: 20px">
        <h1 class="text-center text-info">CRUD Form</h1>
        <div class="col-md-8 col-md-offset-2">
            <div class="form-group">
                <div class="row">
                    <div class="col-md-2">
                        <label>Name</label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-2 col-md-offset-2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-8 col-md-offset-2">
            <asp:GridView ID="gvPet" runat="server" CssClass="table table-hover" AutoGenerateColumns="False"
                DataKeyNames="id" OnRowDeleting="gvPet_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvPet_PageIndexChanging" PageSize="5" OnSelectedIndexChanging="gvPet_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="No">
                        <ItemTemplate>
                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Cat Name" DataField="name" />
                    <asp:HyperLinkField Text="Update" DataNavigateUrlFields="id"
                        DataNavigateUrlFormatString="Edit.aspx?id={0}" HeaderText="Edit" ControlStyle-CssClass="btn btn-info">
                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Are you sure to delete');" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle CssClass="btn btn-danger" />
                    </asp:TemplateField>
                </Columns>

                <PagerStyle Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="page" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>