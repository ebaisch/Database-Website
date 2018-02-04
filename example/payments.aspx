<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="payments.aspx.cs" Inherits="payments" EnableEventValidation = "false"%>


<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

        <link href="css/search.css" rel="stylesheet" />
    <div class ="mainPage">
        <div class="search">
            <div class="col-md-9" id="checkout">

                    <div class="box">
                            <div class="content">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="firstname">Name (used at checkout)</asp:Label>
                                            <asp:TextBox runat="server" name="firstname" type="text" class="form-control" id="nameTextBox"/>
                                        </div>
                                    </div>
                                 <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:DropDownList ID="paymentTypeDropDownList" runat="server" OnSelectedIndexChanged="paymentTypeDropDownList_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->

                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="street">Card Number</asp:Label>
                                            <asp:TextBox runat="server" name="street" type="text" class="form-control" id="cardNumberTextBox"/>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->

                                <div class="row">
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="city">EXP</asp:Label>
                                            <asp:TextBox runat="server" name="city" type="text" class="form-control" id="expTextBox"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="zip">CSV</asp:Label>
                                            <asp:TextBox runat="server" name="zip" type="text" class="form-control" id="csvTextBox"/>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->
                            </div>
                    </div>
                    <!-- /.box -->


                </div>
            <br><br>
            <asp:Button ID="saveAddress" runat="server" Text="Add Paymeent Option" CssClass="loginButton" OnClick="savePaymentOnClick" />
            <br><br>
</div>
    </div>

    <div class="list">
            <asp:GridView ID="searchResults" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Records Found." ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True" CssClass="gridViewClass" EnablePersistedSelection="False" OnSelectedIndexChanging="searchResults_SelectedIndexChanging" OnRowDataBound="searchResults_RowDataBound" OnSelectedIndexChanged="searchResults_SelectedIndexChanged1">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" />
                    <asp:BoundField DataField="payment_type" HeaderText="Payment Type" ReadOnly="True" />
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
