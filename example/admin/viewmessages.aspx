<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="viewmessages.aspx.cs" Inherits="admin_viewmessages" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <div class="list">
            <asp:GridView ID="searchResults" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Records Found." ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True" CssClass="gridViewClass" EnablePersistedSelection="False" OnRowDataBound="searchResults_RowDataBound" OnSelectedIndexChanged="searchResults_SelectedIndexChanged1" OnSelectedIndexChanging="SearchResultsChanging">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="first_name" HeaderText="First Name" ReadOnly="True" />
                    <asp:BoundField DataField="email" HeaderText="E-Mail" ReadOnly="True" />
                    <asp:BoundField DataField="subject" HeaderText="Subject" ReadOnly="True" />
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

</asp:Content>