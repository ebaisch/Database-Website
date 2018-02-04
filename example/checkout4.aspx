<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkout4.aspx.cs" Inherits="checkout4" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>Checkout - Order review</li>
                    </ul>
                </div>

                <div class="col-md-9" id="checkout">

                    <div class="box">
                            <h1>Checkout - Order review</h1>
                            <ul class="nav nav-pills nav-justified">
                                <li><a href="checkout1.aspx"><i class="fa fa-map-marker"></i><br/>Address</a>
                                </li>
                                <li><a href="checkout2.aspx"><i class="fa fa-truck"></i><br/>Delivery Method</a>
                                </li>
                                <li><a href="checkout3.aspx"><i class="fa fa-money"></i><br/>Payment Method</a>
                                </li>
                                <li class="active"><a href="#"><i class="fa fa-eye"></i><br/>Order Review</a>
                                </li>
                            </ul>

                            <div class="content">
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Product</th>
                                                <th>Quantity</th>
                                                <th>Unit price</th>                          
                                                <th>Total</th>
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
                                                <a href="#"><%# Eval("description") %></a>
                                            </td>
                                            <td>
                                                <asp:Label  runat="server" name="quanity" type="number" Text=<%# Eval("quanity") %> class="form-control" ID="quanityTextBox" Width="75" MaxLength="3" />
                                            </td>
                                            <td> 
                                                <asp:Label ID="priceLabel" runat="server" Text=<%# Eval("price") %>></asp:Label>
                                            </td>
                                           
                                            <td>
                                                <asp:Label ID="totalLabel" runat="server" Text=<%# "$" + Math.Round(Convert.ToDouble(Eval("price")) * Convert.ToDouble(Eval("quanity")), 2) %>></asp:Label>
                                            </td>
                                    
                                            <td>
                                                   <asp:Label ID="productIDLabel" runat="server" style="display: none;" Text=<%# Eval("product_id") %>></asp:Label>
                                            </td>
                                        </tr>


                                           </ItemTemplate>
                                        </asp:Repeater>
                                        </tbody>
              
                                    </table>

                                </div>
                                <!-- /.table-responsive -->
                            </div>
                            <!-- /.content -->

                            <div class="box-footer">
                                <div class="pull-left">
                                    <a href="checkout3.aspx" class="btn btn-default"><i class="fa fa-chevron-left"></i>Back to Payment method</a>
                                </div>
                                <div class="pull-right">
                                    <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Place An Order" OnClick="PlaceOrder">
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
    <!-- /#all -->
</asp:content>
