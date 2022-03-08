<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="SalutationCreate.aspx.cs" Inherits="SampleTaskList.Views.Salutation.SalutationCreate1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hfSalutation" runat="server" />
            <h1>
                <asp:Label ID="LblSalutation" runat="server" Text="Label"></asp:Label></h1>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="exampleInputPassword1">Salutation</label>
                    <span class="fill">*</span>
                    <asp:TextBox ID="txtSalutation" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSalutation" ErrorMessage="Please fill salutation" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-info" CausesValidation="False" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-info" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>