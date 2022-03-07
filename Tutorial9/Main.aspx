<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Tutorial9.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnExcel" runat="server" Text="Fetching data from Excel" OnClick="btnExcel_Click" BackColor="#99FFCC" BorderStyle="Groove" Font-Bold="True" Font-Size="Large" Height="50px" Width="300px" Style="cursor: pointer" /><br />
            <br />
            <br />
            <asp:Button ID="btnCSV" runat="server" OnClick="btnCSV_Click" Text="Fetching data from CSV file" BackColor="#99FFCC" BorderStyle="Groove" Font-Bold="True" Font-Size="Large" Height="50px" Width="300px" Style="cursor: pointer" /><br />
            <br />
            <br />
            <asp:Button ID="btnText" runat="server" OnClick="btnText_Click" Text="Fetching data from Text file" BackColor="#99FFCC" BorderStyle="Groove" Font-Bold="True" Font-Size="Large" Height="50px" Width="300px" Style="cursor: pointer" /><br />
            <br />
            <br />
            <asp:Button ID="btnDoc" runat="server" OnClick="btnDoc_Click" Text="Fetching data from Document" BackColor="#99FFCC" BorderStyle="Groove" Font-Bold="True" Font-Size="Large" Height="50px" Width="300px" Style="cursor: pointer" />
            <br />
            <br />
            <asp:GridView ID="gvFile" runat="server" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>