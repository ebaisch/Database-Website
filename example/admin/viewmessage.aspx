<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="viewmessage.aspx.cs" Inherits="admin_viewmessage" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="server">
    <div class="col-md-9">


                    <div class="box" id="contact">
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
                                        <asp:TextBox runat="server" id="message" class="form-control" name="message_textbox" MaxLength="255" TextMode="MultiLine" Rows="8" Width="500px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>

    </asp:Content>