<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <div id="all">

        <div id="content">
            <div class="container">

                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="#">Home</a>
                        </li>
                        <li>Contact</li>
                    </ul>

                </div>

                <div class="col-md-3">
                    <!-- *** PAGES MENU ***
 _________________________________________________________ -->
                    <div class="panel panel-default sidebar-menu">

                        <div class="panel-heading">
                            <h3 class="panel-title">Pages</h3>
                        </div>

                        <div class="panel-body">
                            <ul class="nav nav-pills nav-stacked">
                                <li>
                                    <a href="text.aspx">Text page</a>
                                </li>
                                <li>
                                    <a href="contact.aspx">Contact page</a>
                                </li>
                                <li>
                                    <a href="faq.aspx">FAQ</a>
                                </li>

                            </ul>

                        </div>
                    </div>

                    <!-- *** PAGES MENU END *** -->


                </div>

                <div class="col-md-9">


                    <div class="box" id="contact">
                        <h1>Contact</h1>

                        <p class="lead">Are you curious about something? Do you have some kind of problem with our products?</p>
                        <p>Please feel free to contact us, our customer service center is working for you 24/7.</p>

                        <hr>

                        <div class="row">
                            <div class="col-sm-4">
                                <h3><i class="fa fa-map-marker"></i> Address</h3>
                                <p>100 Nicolls Rd
                                    <br>Stony Brook
                                    <br>New York
                                    <br>11794
                                    <br>
                                    <strong>United States</strong>
                                </p>
                            </div>
                            <!-- /.col-sm-4 -->
                            <div class="col-sm-4">
                                <h3><i class="fa fa-phone"></i> Call center</h3>
                                <p class="text-muted">This number is toll free if calling from United States otherwise we advise you to use the electronic form of communication.</p>
                                <p><strong>+***-***-****</strong>
                                </p>
                            </div>
                            <!-- /.col-sm-4 -->
                            <div class="col-sm-4">
                                <h3><i class="fa fa-envelope"></i> Electronic support</h3>
                                <p class="text-muted">Please feel free to write an email to us or to use our electronic ticketing system.</p>
                                <ul>
                                    <li><strong><a href="mailto:">test@gmail.com</a></strong>
                                    </li>
                                </ul>
                            </div>
                            <!-- /.col-sm-4 -->
                        </div>
                        <!-- /.row -->

                        <hr>

                        <div id="map">

                        </div>

                        <hr>
                        <h2>Contact form</h2>
                        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="firstname" name="firstname">Firstname</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="firstname"/>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="lastname" name="lastname">Lastname</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="lastname"/>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="email" name="email_label">Email</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="email"/>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="subject" name="subject">Subject</asp:Label>
                                        <asp:TextBox runat="server" type="text" class="form-control" id="subject"/>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <asp:Label runat="server" for="message" name="message">Message</asp:Label>
                                        <asp:TextBox runat="server" id="message" class="form-control" name="message_textbox" MaxLength="255" TextMode="MultiLine" Rows="8"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-12 text-center">
                                    <asp:Button runat="server" type="submit" class="btn btn-primary" name="submit_button" Text="Send Message" ID="sendMessageButton" OnClick="SendMessageOnClick"></asp:Button>

                                </div>
                            </div>
                            <!-- /.row -->


                    </div>


                </div>
                <!-- /.col-md-9 -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /#content -->



    </div>
    <!-- /#all -->


    

    <!-- *** SCRIPTS TO INCLUDE ***
 _________________________________________________________ -->
    <script src="js/jquery-1.11.0.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/waypoints.min.js"></script>
    <script src="js/modernizr.js"></script>
    <script src="js/bootstrap-hover-dropdown.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/front.js"></script>




    <!--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAS3b2NQVrGjVKqL1TcABaEzenYvI4lTlk&v=3.exp&amp;sensor=false"></script> -->
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAS3b2NQVrGjVKqL1TcABaEzenYvI4lTlk&callback=initialize"
  type="text/javascript"></script>
    
    <script>
        function initialize() {
            var mapOptions = {
                zoom: 15,
                center: new google.maps.LatLng(40.9256538, -73.140943),
                mapTypeId: google.maps.MapTypeId.ROAD,
                scrollwheel: false
            }
            var map = new google.maps.Map(document.getElementById('map'),
                mapOptions);

            var myLatLng = new google.maps.LatLng(40.9256538, -73.140943);
            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map
            });
        }

        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>