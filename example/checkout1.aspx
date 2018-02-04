<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkout1.aspx.cs" Inherits="checkout1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>Checkout - Address</li>
                    </ul>
                </div>

                <div class="col-md-9" id="checkout">

                    <div class="box">
                            <h1>Checkout</h1>
                            <ul class="nav nav-pills nav-justified">
                                <li class="active"><a href="#"><i class="fa fa-map-marker"></i><br/>Address</a>
                                </li>
                                <li class="disabled"><a href="#"><i class="fa fa-truck"></i><br/>Delivery Method</a>
                                </li>
                                <li class="disabled"><a href="#"><i class="fa fa-money"></i><br/>Payment Method</a>
                                </li>
                                <li class="disabled"><a href="#"><i class="fa fa-eye"></i><br/>Order Review</a>
                                </li>
                            </ul>

                            <div class="content">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <asp:Label runat="server">Customer Existing Address:</asp:Label>
                                            <asp:DropDownList ID="shippingDropDownList"  runat="server"> 
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                       <div class="col-sm-6">
                                            <div class="form-group">
                                                <a href="shipping.aspx" runat="server" style="font-size:small;font-family:Arial;" id="mylink">New Address Click here</a>
                                            </div>
                                    </div>
    
                                </div>
                                <!-- /.row -->
                            </div>

                            <div class="box-footer">
                                <div class="pull-left">
                                    <a href="basket.aspx" class="btn btn-default"><i class="fa fa-chevron-left"></i>Back to basket</a>
                                </div>
                                <div class="pull-right">
                                    <asp:Button runat="server" name="submit" type="submit" class="btn btn-primary" Text="Continue to Delivery" OnClick="ToCheckout2">
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
</asp:Content>