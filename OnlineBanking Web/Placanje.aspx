<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Placanje.aspx.cs" Inherits="OnlineBanking_Web.Placanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/StyleSheetPlacanje.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="placanje">
        <select id="listaPlacanje" runat="server"></select>
       <input type="text" id="primaocRacun" placeholder="Unesi racun primaoca" runat="server">
        <input type="text" id="placanjeSuma" placeholder="Unesi sumu" runat="server">
        <button id="btnPlati" runat="server" onserverclick="btnPlati_ServerClick">Izvrsi uplatu</button>
    </div>
</asp:Content>
