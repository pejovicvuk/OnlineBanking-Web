<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineBanking_Web.Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login form</title>
    <link rel="stylesheet" href="CSS/StyleSheetRegistration.css" />
</head>
    <script src="JS/JavaScript.js">
    </script>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <h2>Login</h2>
            <div class="input-box">
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Enter your email" required="true"></asp:TextBox>
            </div>
            <div class="input-box">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter your password" required="true"></asp:TextBox>
            </div>
            <div class="policy">
                <asp:CheckBox ID="chkTerms" runat="server" />
                <h3>I accept all terms & condition</h3>
            </div>
            <div class="input-box button">
                <asp:Button ID="btnLogin" runat="server" Text="Uloguj se" OnClick="btnLogin_Click"/>
            </div>
            <div class="text">
                <h3>Nemate nalog? <a href="Register.aspx">Ulogujte se</a></h3>
            </div>
        </div>
    </form>
</body>
</html>

