<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="admin_search" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <link href="css/search.css" rel="stylesheet" />
    <div class ="mainPage">
        <div class="search">
            <asp:DropDownList ID="searchOptionDropDownList" runat="server" CssClass="dropDownClass">
                <asp:ListItem Selected="True">Product Name</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="searchLabel" runat="server" Text="Search" CssClass="searchClass"></asp:Label>
            <asp:TextBox ID="searchTextBox" runat="server" OnTextChanged="searchTextBoxChanged" AutoPostBack="True" name="user"></asp:TextBox>
        </div>
        <div class="list">
            <asp:GridView ID="searchResults" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Records Found." ForeColor="Black" GridLines="Vertical" OnDataBinding="bindData" ShowHeaderWhenEmpty="True" CssClass="gridViewClass" EnablePersistedSelection="False" OnRowDataBound="searchResults_RowDataBound" OnSelectedIndexChanged="searchResults_SelectedIndexChanged1" OnSelectedIndexChanging="SearchResultsChanging">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Product ID" SortExpression="usernameSort" ReadOnly="True" />
                    <asp:BoundField DataField="name" HeaderText="Product Name" SortExpression="givennameSort" ReadOnly="True" />
                    <asp:BoundField DataField="quanity" HeaderText="Quanity" SortExpression="surnameSort" ReadOnly="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>