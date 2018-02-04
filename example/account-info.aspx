<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account-info.aspx.cs" Inherits="account_info" EnableEventValidation = "false"  %>

<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

        <link href="css/search.css" rel="stylesheet" />
    <div class ="mainPage">
        <div class="search">
            <asp:LinkButton ID="LinkButton1" runat="server" href="/shipping.aspx">Edit Shipping Info</asp:LinkButton>
            <br><br>
            <asp:LinkButton ID="LinkButton2" runat="server" href="/payments.aspx">Edit Payment Info</asp:LinkButton>
            <br><br>
            <asp:Label ID="errorLabel" runat="server" Text="" CssClass="searchClass"></asp:Label>
            <br>
            <asp:Label ID="oldPasswordLabel" runat="server" Text="Old Password: " CssClass="searchClass"></asp:Label>
            <asp:TextBox ID="oldPasswordTextBox" runat="server" Type="password" CssClass="searchClass"></asp:TextBox>
            <br><br>
            <asp:Label ID="newPasswordLabel1" runat="server" Text="New Password: " CssClass="searchClass"></asp:Label>
            <asp:TextBox ID="newPasswordTextBox1" runat="server" Type="password" CssClass="searchClass"></asp:TextBox>
            <br><br>
            <asp:Label ID="newPasswordLabel2" runat="server" Text="New Password: " CssClass="searchClass"></asp:Label>
            <asp:TextBox ID="newPasswordTextBox2" runat="server" Type="password" CssClass="searchClass"></asp:TextBox>
            <br><br>
            <asp:Button ID="passwordButton" runat="server" Text="Change Password" CssClass="loginButton" OnClick="PasswordButtonOnClick" />
            <br><br>
</div>
        <div class="list">
            <asp:GridView ID="searchResults" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Records Found." ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True" CssClass="gridViewClass" EnablePersistedSelection="False" OnSelectedIndexChanging="searchResults_SelectedIndexChanging" OnRowDataBound="searchResults_RowDataBound" OnSelectedIndexChanged="searchResults_SelectedIndexChanged1">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="order_number" HeaderText="Order Number" SortExpression="givennameSort" ReadOnly="True" />
                    <asp:BoundField DataField="order_date" HeaderText="Order Date" SortExpression="usernameSort" ReadOnly="True" />
                    <asp:BoundField DataField="total_price" HeaderText="Total Price" SortExpression="surnameSort" ReadOnly="True" />
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