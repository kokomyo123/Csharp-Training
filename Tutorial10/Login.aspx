<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tutorial10.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1>Login Form</h1>
                <fieldset style="border: 1px solid; border-radius: 10px; padding: 20px; text-align: left; width: 350px">
                    <legend>Login</legend>
                    <table>
                        <tr>
                            <td>User Name:</td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Password:</td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
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