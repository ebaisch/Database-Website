<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="css/login.css" rel="stylesheet" />
    <form id="form1" runat="server">
        <div class="wrapper">
        <div class="invalid">
            <asp:Label ID="invalidCredentials" runat="server" Text="Invalid Credentials" CssClass="invalidCred"></asp:Label>
        </div>
        <div class="loginbox">
            <!-- fake fields are a workaround for chrome autofill getting the wrong fields -->
            <input style="display:none" type="text" name="fakeusernameremembered"/>
            <input style="display:none" type="password" name="fakepasswordremembered"/>
            <div class="username">
                <asp:Label ID="usernameLabel" runat="server" Text="Username: " Font-Bold="False" CssClass="labels"></asp:Label>
                <asp:TextBox ID="usernameTextBox" runat="server" Font-Size="22pt" autocomplete="off"></asp:TextBox>
            </div>
            <div class="password">
                <asp:Label ID="passwordLabel" runat="server" Text="Password: " Font-Bold="False" CssClass="labels"></asp:Label>
                <asp:TextBox ID="passwordTextBox" TextMode="Password" runat="server" Font-Size="22pt" autocomplete="off"></asp:TextBox>
            </div>
            <div class="login">
                <asp:Button ID="loginButton" runat="server" Text="Login"  CssClass="loginButton" OnClick="loginButtonOnClick"/>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
