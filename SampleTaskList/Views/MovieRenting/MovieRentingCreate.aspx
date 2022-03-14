<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieRentingCreate.aspx.cs" Inherits="SampleTaskList.Views.MovieRenting.MovieRentingCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hfMovieRent" runat="server" />
            <h1>
                <asp:Label ID="lblMovierent" runat="server" Text="Label"></asp:Label></h1>
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="exampleInputPassword1">Movie</label>
                    <span class="fill">*</span>
                    <asp:DropDownList ID="ddlMovie" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Customer</label>
                    <span class="fill">*</span>
                    <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info" OnClick="btnClear_Click" CausesValidation="False" />
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-info" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
</asp:Content>