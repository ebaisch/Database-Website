<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="basket.aspx.cs" Inherits="basket" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    
    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>Shopping cart</li>
                    </ul>
                </div>

                <div class="col-md-9" id="basket">

                    <div class="box">


                            <h1>Shopping cart</h1>
<%--                            <p class="text-muted">You currently have 3 item(s) in your cart.</p>--%>
                        <br>
                        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
                        <br>
                            <div class="table-responsive">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th colspan="2">Product</th>                                       
                                            <th>Quantity</th>
                                            <th>Unit price</th>
                                            <th colspan="2">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server" >
                                        <ItemTemplate>
                                        <tr>
                                            <td>
                                                <a href="#">
                                                    <img src="img/detailsquare.jpg" alt="White Blouse Armani"/>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="#"><%# Eval("name") %></a>
                                            </td>
                                            <td>
                                                <asp:TextBox  runat="server" name="quanity" type="number" min="0" Text=<%# Eval("quanity") %> class="form-control" ID="quanityTextBox" Width="75" MaxLength="3" />
                                            </td>
                                            <td> 
                                                <asp:Label ID="priceLabel" runat="server" Text=<%# Eval("price") %>></asp:Label>
                                            </td>
                                           
                                            <td>
                                                <asp:Label ID="totalLabel" runat="server" Text=<%# "$" + Math.Round(Convert.ToDouble(Eval("price")) * Convert.ToDouble(Eval("quanity")), 2) %>></asp:Label>
                                            </td>
                                            <td>                                       
                                                <asp:LinkButton ID="deleteItem" runat="server" class="fa fa-trash-o" OnCommand="DeleteOnClick" CommandArgument=<%# Eval("product_id") %>></asp:LinkButton>
                                            </td>
                                            <td>
                                                   <asp:Label ID="productIDLabel" runat="server" style="display: none;" Text=<%# Eval("product_id") %>></asp:Label>
                                                <asp:Label ID="productNameLabel" runat="server" style="display: none;" Text=<%# Eval("name") %>></asp:Label>
                                            </td>
                                        </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    </tbody>

                                </table>

                            </div>
                            <!-- /.table-responsive -->

                            <div class="box-footer">
                                <div class="pull-left">
                                    <a href="category-full.aspx" class="btn btn-default"><i class="fa fa-chevron-left"></i> Continue shopping</a>
                                </div>
                                <div class="pull-right">
                                    <asp:Button runat="server" name="updatebasket" class="btn btn-default" Text="UpdateBasket" ID="updateBasket" OnClick="UpdateCart"></asp:Button>
                                    <asp:Button runat="server" name="proceedcheckout" type="submit" class="btn btn-primary" Text="Proceed To Checkout" OnClick="CheckoutCart">
                                    </asp:Button>
                                </div>
                            </div>

                    </div>
                    <!-- /.box -->


           


                </div>
                <!-- /.col-md-9 -->

                <div class="col-md-3">
                    <div class="box" id="order-summary">
                        <div class="box-header">
                            <h3>Order summary</h3>
                        </div>
                        <p class="text-muted">Shipping and additional costs are calculated based on the values you have entered.</p>

                        <div class="table-responsive">
                            <table class="table">
                                 <tbody>
                                    <tr>
                                        <td>Order subtotal</td>
                                        <%--<th>$446.00</th>--%>
                                        <th><asp:Label ID="sideOrderSubtotal" runat="server" Text="Label"></asp:Label></th>
                                        
                                    </tr>
                                    <tr>
                                        <td>Shipping and handling</td>
                                        <%--<th>$10.00</th>--%>
                                        <th><asp:Label ID="sideShippingHandling" runat="server" Text="Label"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td>Tax</td>
                                       <th><asp:Label ID="sideTax" runat="server" Text="Label"></asp:Label></th>
                                    </tr>
                                    <tr class="total">
                                        <td>Total</td>
                                       <th><asp:Label ID="sideTotal" runat="server" Text="Label"></asp:Label></th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                    </div>

                </div>
                <!-- /.col-md-3 -->

            </div>
            <!-- /.container -->
        </div>
        <!-- /#content -->

    </div>
</asp:Content>