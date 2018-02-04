<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="category-full.aspx.cs" Inherits="category_full" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">

                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>Product</li>
                    </ul>

                    <div class="box">
                        <h1>Products</h1>
                        <p>Our Store provides the best product in United States</p>
                    </div>
                   
                    <div class="box info-bar">
                        <div class="row">
                            <div class="col-sm-12 col-md-4 products-showing">
                                Showing <strong>12</strong> of <strong>25</strong> products
                            </div>

                            <div class="col-sm-12 col-md-8  products-number-sort">
                                <div class="row">
                                        <div class="col-md-6 col-sm-6">
                                            <div class="products-number">
                                                <strong>Show</strong>  <a href="#" class="btn btn-default btn-sm btn-primary">12</a>  <a href="#" class="btn btn-default btn-sm">24</a>  <a href="#" class="btn btn-default btn-sm">All</a> products
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6">
                                            <div class="products-sort-by">
                                                <strong>Sort by</strong>
                                                <asp:DropDownList runat="server" name="sort-by" class="form-control">
                                                    <asp:ListItem>Price</asp:ListItem>
                                                    <asp:ListItem>Name</asp:ListItem>
                                                    <asp:ListItem>Sales first</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row products">

                   


  <table>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr id="exp">

                        <div class="col-md-3 col-sm-4">
                            <div class="product">
                                <div class="flip-container">
                                    <div class="flipper">
                                        <div class="front">
                                            <a href="basket.aspx?product_id=<%# Eval("product_id") %>">
                                                <img src="img/product1.jpg" alt="" class="img-responsive" id="img1" />
                                            </a>
                                        </div>
                                        <div class="back">
                                            <a href="basket.aspx?product_id=<%# Eval("product_id") %>">
                                                <img src="img/product1_2.jpg" alt="" class="img-responsive" id="img2" />
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <a href="basket.aspx?product_id=<%# Eval("product_id") %>" class="invisible">
                                    <img src="img/product1.jpg" alt="" class="img-responsive" id="img3" />
                                </a>
                                <div class="text">
                                    <h3><%# Eval("description") %></a></h3>
                                    <p class="price"><%# Eval("name") %></p>
                                    <p class="buttons"> 
                                        <!-- <a href="basket.aspx?product_id=FIXME" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart<</a> -->
                                        <a href="basket.aspx?product_id=<%# Eval("product_id") %>" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart<</a>
                                    </p>
                                </div>
                                <!-- /.text -->
                            </div>
                            <!-- /.product -->
                        </div>

            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>


                    </div>
                    <!-- /.products -->

                    <div class="pages">

                        <p class="loadMore">
                            <a href="#" class="btn btn-primary btn-lg"><i class="fa fa-chevron-down"></i> Load more</a>
                        </p>

                        <ul class="pagination">
                            <li><a href="#">&laquo;</a>
                            </li>
                            <li class="active"><a href="#">1</a>
                            </li>
                            <li><a href="#">2</a>
                            </li>
                            <li><a href="#">3</a>
                            </li>
                            <li><a href="#">4</a>
                            </li>
                            <li><a href="#">5</a>
                            </li>
                            <li><a href="#">&raquo;</a>
                            </li>
                        </ul>
                    </div>


                </div>
                <!-- /.col-md-9 -->

            </div>
            <!-- /.container -->
        </div>
        <!-- /#content -->



    </div>
    <!-- /#all -->
</asp:Content>