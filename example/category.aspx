<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="category.aspx.cs" Inherits="category" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>Ladies</li>
                    </ul>
                </div>

                <div class="col-md-3">
                    <!-- *** MENUS AND FILTERS ***
 _________________________________________________________ -->
                    <div class="panel panel-default sidebar-menu">

                        <div class="panel-heading">
                            <h3 class="panel-title">Categories</h3>
                        </div>

                        <div class="panel-body">
                            <ul class="nav nav-pills nav-stacked category-menu">
                                <li class="active">
                                    <a href="category.aspx">Products  <span class="badge pull-right">123</span></a>
                                    <ul> <!--
                                        <li><a href="category.aspx">All-Products</a>
                                        </li>
                                        <li><a href="category.aspx">Skirts</a>
                                        </li>
                                        <li><a href="category.aspx">Pants</a>
                                        </li>
                                        <li><a href="category.aspx">Accessories</a>
                                        </li> -->
                                    </ul>
                                </li>
                            </ul>

                        </div>
                    </div>

                    <!-- *** MENUS AND FILTERS END *** -->

                </div>

                <div class="col-md-9">
                    <div class="box">
                        <h1>Products</h1>
                        <p>In our Products department we offer wide selection of the best products we have found and carefully selected worldwide.</p>
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

                        <div class="col-md-4 col-sm-6">
                            <div class="product">
                                <div class="flip-container">
                                    <div class="flipper">
                                        <div class="front">
                                            <a href="detail.aspx">
                                                <img src="img/product1.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                        <div class="back">
                                            <a href="detail.aspx">
                                                <img src="img/product1_2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <a href="detail.aspx" class="invisible">
                                    <img src="img/product1.jpg" alt="" class="img-responsive"/>
                                </a>
                                <div class="text">
                                    <h3><a href="detail.aspx">Fur coat with very but very very long name</a></h3>
                                    <p class="price">$143.00</p>
                                    <p class="buttons">
                                        <a href="detail.aspx" class="btn btn-default">View detail</a>
                                        <a href="basket.aspx" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                    </p>
                                </div>
                                <!-- /.text -->
                            </div>
                            <!-- /.product -->
                        </div>

                        <div class="col-md-4 col-sm-6">
                            <div class="product">
                                <div class="flip-container">
                                    <div class="flipper">
                                        <div class="front">
                                            <a href="detail.aspx">
                                                <img src="img/product2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                        <div class="back">
                                            <a href="detail.aspx">
                                                <img src="img/product2_2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <a href="detail.aspx" class="invisible">
                                    <img src="img/product2.jpg" alt="" class="img-responsive"/>
                                </a>
                                <div class="text">
                                    <h3><a href="detail.aspx">White Blouse Armani</a></h3>
                                    <p class="price"><del>$280</del> $143.00</p>
                                    <p class="buttons">
                                        <a href="detail.aspx" class="btn btn-default">View detail</a>
                                        <a href="basket.aspx" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                    </p>
                                </div>
                                <!-- /.text -->

                                <div class="ribbon sale">
                                    <div class="theribbon">SALE</div>
                                    <div class="ribbon-background"></div>
                                </div>
                                <!-- /.ribbon -->

                                <div class="ribbon new">
                                    <div class="theribbon">NEW</div>
                                    <div class="ribbon-background"></div>
                                </div>
                                <!-- /.ribbon -->

                                <div class="ribbon gift">
                                    <div class="theribbon">GIFT</div>
                                    <div class="ribbon-background"></div>
                                </div>
                                <!-- /.ribbon -->
                            </div>
                            <!-- /.product -->
                        </div>

                        <div class="col-md-4 col-sm-6">
                            <div class="product">
                                <div class="flip-container">
                                    <div class="flipper">
                                        <div class="front">
                                            <a href="detail.aspx">
                                                <img src="img/product3.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                        <div class="back">
                                            <a href="detail.aspx">
                                                <img src="img/product3_2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <a href="detail.aspx" class="invisible">
                                    <img src="img/product3.jpg" alt="" class="img-responsive"/>
                                </a>
                                <div class="text">
                                    <h3><a href="detail.aspx">Black Blouse Versace</a></h3>
                                    <p class="price">$143.00</p>
                                    <p class="buttons">
                                        <a href="detail.aspx" class="btn btn-default">View detail</a>
                                        <a href="basket.aspx" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                    </p>

                                </div>
                                <!-- /.text -->
                            </div>
                            <!-- /.product -->
                        </div>

                        <div class="col-md-4 col-sm-6">
                            <div class="product">
                                <div class="flip-container">
                                    <div class="flipper">
                                        <div class="front">
                                            <a href="detail.aspx">
                                                <img src="img/product3.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                        <div class="back">
                                            <a href="detail.aspx">
                                                <img src="img/product3_2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <a href="detail.aspx" class="invisible">
                                    <img src="img/product3.jpg" alt="" class="img-responsive"/>
                                </a>
                                <div class="text">
                                    <h3><a href="detail.aspx">Black Blouse Versace</a></h3>
                                    <p class="price">$143.00</p>
                                    <p class="buttons">
                                        <a href="detail.aspx" class="btn btn-default">View detail</a>
                                        <a href="basket.aspx" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                    </p>

                                </div>
                                <!-- /.text -->
                            </div>
                            <!-- /.product -->
                        </div>

                        <div class="col-md-4 col-sm-6">
                            <div class="product">
                                <div class="flip-container">
                                    <div class="flipper">
                                        <div class="front">
                                            <a href="detail.aspx">
                                                <img src="img/product2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                        <div class="back">
                                            <a href="detail.aspx">
                                                <img src="img/product2_2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <a href="detail.aspx" class="invisible">
                                    <img src="img/product2.jpg" alt="" class="img-responsive"/>
                                </a>
                                <div class="text">
                                    <h3><a href="detail.aspx">White Blouse Versace</a></h3>
                                    <p class="price">$143.00</p>
                                    <p class="buttons">
                                        <a href="detail.aspx" class="btn btn-default">View detail</a>
                                        <a href="basket.aspx" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                    </p>

                                </div>
                                <!-- /.text -->

                                <div class="ribbon new">
                                    <div class="theribbon">NEW</div>
                                    <div class="ribbon-background"></div>
                                </div>
                                <!-- /.ribbon -->
                            </div>
                            <!-- /.product -->
                        </div>

                        <div class="col-md-4 col-sm-6">
                            <div class="product">
                                <div class="flip-container">
                                    <div class="flipper">
                                        <div class="front">
                                            <a href="detail.aspx">
                                                <img src="img/product1.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                        <div class="back">
                                            <a href="detail.aspx">
                                                <img src="img/product1_2.jpg" alt="" class="img-responsive"/>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <a href="detail.aspx" class="invisible">
                                    <img src="img/product1.jpg" alt="" class="img-responsive"/>
                                </a>
                                <div class="text">
                                    <h3><a href="detail.aspx">Fur coat</a></h3>
                                    <p class="price">$143.00</p>
                                    <p class="buttons">
                                        <a href="detail.aspx" class="btn btn-default">View detail</a>
                                        <a href="basket.aspx" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                    </p>

                                </div>
                                <!-- /.text -->

                                <div class="ribbon gift">
                                    <div class="theribbon">GIFT</div>
                                    <div class="ribbon-background"></div>
                                </div>
                                <!-- /.ribbon -->

                            </div>
                            <!-- /.product -->
                        </div>
                        <!-- /.col-md-4 -->
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