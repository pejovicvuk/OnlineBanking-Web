<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Nalog.aspx.cs" Inherits="OnlineBanking_Web.Nalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/StyleSheetNalog.css"/>
    <script src="JS/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nalog-form">
    <div class="form-row">
        <div class="label">Ime:</div>
        <div id="imeNalog" class="template" runat="server">imetemplate</div>
    </div>
    <div class="form-row">
        <div class="label">Prezime:</div>
        <div id="prezimeNalog" class="template" runat="server">prezimetemplate</div>
    </div>
    <div class="form-row">
        <div class="label">Email:</div>
        <div id="emailNalog" class="template" runat="server">emailtemplate</div>
    </div>
    <div class="form-row">
        <div class="label">Lozinka:</div>
        <asp:TextBox ID="lozinkaNalog" ReadOnly="true" runat="server"></asp:TextBox>
        <div class="checkbox">
            <input type="checkbox" id="showPassword" runat="server" onchange="togglePasswordVisibility()">
            <label for="showPassword">Show Password</label>
        </div>
    </div>
</div>
    <script>
        function togglePasswordVisibility() {
            var passwordInput = document.getElementById('<%= lozinkaNalog.ClientID %>');
            passwordInput.type = passwordInput.type === 'password' ? 'text' : 'password';
        }
        window.onload = function () {
            togglePasswordVisibility();
        };
    </script>
</asp:Content>
