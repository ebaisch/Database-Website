<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="modifyemployee.aspx.cs" Inherits="admin_modifyemployee" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <link href="css/login.css" rel="stylesheet" />
    <div class="addProduct">
        <br>
        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
        <br><br>
        <asp:Label ID="employeeNameLabel" runat="server" CssClass="labelss" Text="Employee Name"></asp:Label>
        <asp:TextBox ID="employeeNameTextBox" runat="server" CssClass="textboxes"></asp:TextBox>
        <br><br>
        <asp:Label ID="employeeEmailLabel" runat="server" CssClass="labelss" Text="Employee Email"></asp:Label>
        <asp:TextBox ID="employeeEmailTextBox" runat="server" CssClass="textboxes"></asp:TextBox>
        <br><br>
        <asp:Label ID="employeePasswordLabel" runat="server" CssClass="labelss" Text="Employee Password"></asp:Label>
        <asp:TextBox ID="employeePasswordTextBox" runat="server" CssClass="textboxes"></asp:TextBox>

        <br><br>
        <asp:Button ID="modifyEmployeeButton" runat="server" Text="Modify Employee"  CssClass="loginButton" OnClick="modifyEmployeeOnClick"/>
    </div>
</asp:Content>