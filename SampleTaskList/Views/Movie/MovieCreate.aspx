<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieCreate.aspx.cs" Inherits="SampleTaskList.Views.Movie.MovieCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hfMovie" runat="server" />
            <h1>
                <asp:Label ID="lblMovie" runat="server" Text="Label"></asp:Label></h1>
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="exampleInputPassword1">Movie</label>
                    <span class="fill">*</span>
                    <asp:TextBox ID="txtMovie" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMovie" ErrorMessage="Please fill movie name" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-info" CausesValidation="False" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-info" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>