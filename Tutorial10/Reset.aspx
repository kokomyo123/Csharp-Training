<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="Tutorial10.Reset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1>Reset Password</h1>

                <fieldset style="border: 1px solid; border-radius: 10px; padding: 20px; text-align: left; width: 350px">
                    <table>
                        <tr>
                            <td>New Password:</td>
                            <td>
                                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Confirm Password:</td>
                            <td>
                                <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>

                            <td>
                                <asp:Literal ID="LtlMessage" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </center>
        </div>
    </form>
</body>
</html>