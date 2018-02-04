﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="vieworder.aspx.cs" Inherits="vieworder" EnableEventValidation = "false" %>

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
                                            <asp:Label runat="server" for="firstname">Order Number</asp:Label>
                                            <asp:TextBox runat="server" name="firstname" type="text" class="form-control" id="ordernumberTextBox"/>
                                        </div>
                                    </div>
                                 <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="lastname">Order Date</asp:Label>
                                            <asp:TextBox runat="server" name="lastname" type="text" class="form-control" id="orderDateTextBox"/>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->

                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="street">Sales Tax</asp:Label>
                                            <asp:TextBox runat="server" name="street" type="text" class="form-control" id="salesTaxTextBox"/>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->

                                <div class="row">
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="city">Total Price</asp:Label>
                                            <asp:TextBox runat="server" name="city" type="text" class="form-control" id="totalPriceTextBox"/>
                                        </div>
                                    </div>
                                    

                                </div>
                                <!-- /.row -->
                            </div>
                    </div>
                    <!-- /.box -->

                <div class="box">
                            <div class="content">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        <div class="form-group">
                                            <asp:Label runat="server" for="firstname">Name (used at checkout)</asp:Label>
                                            <asp:TextBox runat="server" name="firstname" type="text" class="form-control" id="nameTextBox"/>
                                        </div>
                                    </div>
                                 <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="lastname">Customer Name</asp:Label>
                                            <asp:TextBox runat="server" name="lastname" type="text" class="form-control" id="customerNameTextBox"/>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->

                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="street">Street</asp:Label>
                                            <asp:TextBox runat="server" name="street" type="text" class="form-control" id="street"/>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->

                                <div class="row">
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="city">City</asp:Label>
                                            <asp:TextBox runat="server" name="city" type="text" class="form-control" id="city"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="zip">ZIP</asp:Label>
                                            <asp:TextBox runat="server" name="zip" type="text" class="form-control" id="zip"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="state">State</asp:Label>
                                            <asp:TextBox runat="server" class="form-control" id="state"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="country">Country</asp:Label>
                                            <asp:TextBox runat="server" class="form-control" id="country"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="phone">Telephone</asp:Label>
                                            <asp:TextBox runat="server" name="phone" type="text" class="form-control" id="phone"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" for="email">Email</asp:Label>
                                            <asp:TextBox runat="server" name="email1" type="text" class="form-control" id="email"/>
                                        </div>
                                    </div>

                                </div>
                                <!-- /.row -->
                            </div>
                    </div>


                </div>
</div>

            <div class="list">
            <asp:GridView ID="searchResults" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EmptyDataText="No Records Found." ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True" CssClass="gridViewClass" EnablePersistedSelection="False" OnSelectedIndexChanging="searchResults_SelectedIndexChanging" OnSelectedIndexChanged="searchResults_SelectedIndexChanged1">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="product_id" HeaderText="Product ID" ReadOnly="True" />
                    <asp:BoundField DataField="price" HeaderText="Price per" ReadOnly="True" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" ReadOnly="True" />
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
