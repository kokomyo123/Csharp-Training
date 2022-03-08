<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Tutorial8.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="text-center text-info">Edit Form</h1>
            <div class="col-md-8 col-md-offset-2">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-2">
                            <label>Name</label>
                        </div>
                        <asp:Label ID="Lblpetid" runat="server" Text="Label" Visible="False"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-md-2 col-md-offset-2">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

