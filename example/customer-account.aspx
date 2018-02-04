<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="customer-account.aspx.cs" Inherits="customer_account" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">

                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>My account</li>
                    </ul>

                </div>

                <div class="col-md-3">
                    <!-- *** CUSTOMER MENU ***
 _________________________________________________________ -->
                    <div class="panel panel-default sidebar-menu">

                        <div class="panel-heading">
                            <h3 class="panel-title">Customer section</h3>
                        </div>

                        <div class="panel-body">

                            <ul class="nav nav-pills nav-stacked">
                                <li class="active">
                                    <a href="customer-orders.aspx"><i class="fa fa-list"></i> My orders</a>
                                </li>
                                <li>
                                    <a href="customer-wishlist.aspx"><i class="fa fa-heart"></i> My wishlist</a>
                                </li>
                                <li>
                                    <a href="customer-account.aspx"><i class="fa fa-user"></i> My account</a>
                                </li>
                                <li>
                                    <a href="index.aspx"><i class="fa fa-sign-out"></i> Logout</a>
                                </li>
                            </ul>
                        </div>

                    </div>
                    <!-- /.col-md-3 -->

                    <!-- *** CUSTOMER MENU END *** -->
                </div>

                <div class="col-md-9">
                    <div class="box">
                        <h1>My account</h1>
                        <p class="lead">Change your personal details or your password here.</p>
                        <p class="text-muted">Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.</p>

                        <h3>Change password</h3>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="password_old" name="oldpassword">Old password</asp:Label>
                                        <asp:TextBox runat="server" type="password" class="form-control" id="password_old" name="passwordold"/>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="password_1" name="newpassword">New password</asp:Label>
                                        <asp:TextBox runat="server" type="password" class="form-control" id="password_1" name="password1"/>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="password_2" name="retype_new_password">Retype new password</asp:Label>
                                        <asp:TextBox runat="server" type="password" class="form-control" id="password_2" name="password2"/>
                                    </div>
                                </div>
                            </div>
                            <!-- /.row -->

                            <div class="col-sm-12 text-center">
                                <asp:Button runat="server" type="submit" class="btn btn-primary" name="submit2" Text="Save Password"></asp:Button>
                            </div>

                        <h3>Personal details</h3>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="firstname" name="firstname">Firstname</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="firstname" name="firstname_textbox"/>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="lastname" name="lastname_label">Lastname</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="lastname" name="lastname_textbox"/>
                                    </div>
                                </div>
                            </div>
                            <!-- /.row -->

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="company" name="company_label">Company</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="company" name="company_textbox"/>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="street" name="street_label">Street</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="street" name="street_textbox"/>
                                    </div>
                                </div>
                            </div>
                            <!-- /.row -->

                            <div class="row">
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="city" name="city_label">Company</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="city" name="city_textbox"/>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="zip" name="zip_label">ZIP</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="zip" name="zip_textbox"/>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="state" name="state">State</asp:Label>
                                        <asp:DropDownList runat="server" class="form-control" id="state"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="country" name="country_label">Country</asp:Label>
                                        <asp:DropDownList runat="server" class="form-control" id="country"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="phone" name="phonr_label">Telephone</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="phone" name="phone_textbox"/>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="email" name="email_label">Email</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="email" name="email_textbox"/>
                                    </div>
                                </div>
                                <div class="col-sm-12 text-center">
                                    <asp:Button runat="server" type="submit" class="btn btn-primary" name="submit_button"></asp:Button>

                                </div>
                            </div>
                    </div>
                </div>

            </div>
            <!-- /.container -->
        </div>
        <!-- /#content -->


    </div>
    <!-- /#all -->
</asp:Content>