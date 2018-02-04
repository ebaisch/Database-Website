<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_index" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <asp:LinkButton ID="addProductButton" runat="server" ForeColor="Black" OnClick="AddProductOnClick">Add Product</asp:LinkButton>
    <br>
    <asp:LinkButton ID="addEmployeeButton" runat="server" ForeColor="Black" OnClick="AddEmployeeOnClick">Add Employee</asp:LinkButton>
    <br>
    <asp:LinkButton ID="viewMessagesButton" runat="server" ForeColor="Black" OnClick="ViewMessagesOnClick">View Messages</asp:LinkButton>
    <br>
    <asp:LinkButton ID="viewEmployeeButton" runat="server" ForeColor="Black" OnClick="ViewEmployeeOnClick">View Employees</asp:LinkButton>
</asp:Content>