<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">

    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">

                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>New account / Sign in</li>
                    </ul>

                </div>

                <div class="col-md-6">
                    <div class="box">
                        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
                        <h1>New account</h1>

                        <p class="lead">Not our registered customer yet?</p>
                        <p>With registration with us new world of fashion, fantastic discounts and much more opens to you! The whole process will not take you more than a minute!</p>
                        <p class="text-muted">If you have any questions, please feel free to <a href="contact.aspx">contact us</a>, our customer service center is working for you 24/7.</p>


                            <div class="form-group">
                                <asp:Label for="name" runat="server">Name</asp:Label>
                                <asp:TextBox runat="server" type="text" class="form-control" id="registerNameTextField" name="name"/>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="email">Email</asp:Label>
                                <asp:TextBox runat="server" type="text" class="form-control" id="registerEmailTextField" name="email"/>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="password">Password</asp:Label>
                                <asp:TextBox runat="server" type="password" class="form-control" id="registerPasswordTextfield" name="password"/>
                            </div>
                            <div class="text-center">
                                <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Register" ID="registerButton" OnClick="RegisterOnClick"></asp:Button>
                            </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="box">
                        <asp:Label ID="invalidCredentialsLabel" runat="server" Text=""></asp:Label>
                        <h1>Login</h1>

                        <p class="lead">Already our customer?</p>
                        <p class="text-muted">Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies
                            mi vitae est. Mauris placerat eleifend leo.</p>

                            <div class="form-group">
                                <asp:Label runat="server" for="email">Email</asp:Label>
                                <asp:TextBox runat="server" type="text" class="form-control" id="loginEmailTextBox"/>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" for="password">Password</asp:Label>
                                <asp:TextBox runat="server" type="password" class="form-control" id="loginPasswordTextBox"/>
                            </div>
                            <div class="text-center">
                                <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Login" ID="loginButton" OnClick="LoginButtonClicked"></asp:Button>
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