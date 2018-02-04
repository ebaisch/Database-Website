<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="modify_payment.aspx.cs" Inherits="modify_payment" %>

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
            <asp:Button ID="savePayment" runat="server" Text="Modify Paymeent Option" CssClass="loginButton" OnClick="savePaymentOnClick" />
            <br><br>
</div>
    </div>
</asp:Content>
