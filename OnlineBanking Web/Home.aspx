<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineBanking_Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/StyleSheetHome.css"/>
    <script src="JS/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="ukupno-stanje-text">Ukupno stanje:</h2>
    <div class="stanje-graphic">
        <div class="stanje-wrapper">
            <div id="stanjeValue" class="stanje-value" runat="server"></div>
            <div class="bar">
                <div class="fill"></div> 
            </div>
        </div>
    </div>
    <h2 class="bankomat-text">Bankomat:</h2>
    <div class="bankomat">
        <select id="listaTransakcije" runat="server"></select>
        <input type="text" id="txtTransakcijaSuma" placeholder="Unesi sumu" runat="server">
        <button id="btnDepozit" runat="server" onserverclick="btnDepozit_Click">Depozit</button>
    </div>
</asp:Content>
