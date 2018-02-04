<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="admin_product" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <link href="css/login.css" rel="stylesheet" />
    <div class="addProduct">
        <br>
        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
        <br><br>
        <asp:Label ID="productNameLabel" runat="server" CssClass="labelss" Text="Product Name"></asp:Label>
        <asp:TextBox ID="productNameTextBox" runat="server" CssClass="textboxes"></asp:TextBox>
        <br><br>
        <asp:Label ID="productDescriptionLabel" runat="server" CssClass="labelss" Text="Product Description"></asp:Label>
        <asp:TextBox ID="productDescriptionTextBox" runat="server" CssClass="textboxes"></asp:TextBox>
        <br><br>
        <asp:Label ID="productPriceLabel" runat="server" CssClass="labelss" Text="Product Price"></asp:Label>
        <asp:TextBox ID="ProductPriceTextBox" runat="server" CssClass="textboxes"></asp:TextBox>
        <br><br>
        <asp:Label ID="quanityLabel" runat="server" CssClass="labelss" Text="Quanity"></asp:Label>
        <asp:TextBox ID="quanityTextBox" runat="server" CssClass="textboxes"></asp:TextBox>
        <br><br>
        <asp:Label ID="productImagePathLabel" runat="server" CssClass="labelss" Text="Product Image Path"></asp:Label>
        <asp:TextBox ID="productImagePathTextBox" runat="server" CssClass="textboxes"></asp:TextBox>
        <br><br>
        <asp:Label ID="isValidLabel" runat="server" Text="Enable Product"></asp:Label>
        <asp:CheckBox ID="isValidCheckBox" runat="server" />
        <br><br>
        <asp:Button ID="modifyProductButton" runat="server" Text="Modify Product"  CssClass="loginButton" OnClick="ModifyProduct"/>
</div>
</asp:Content>