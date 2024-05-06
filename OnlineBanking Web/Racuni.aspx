<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Racuni.aspx.cs" Inherits="OnlineBanking_Web.Racuni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/StyleSheetRacuni.css"/>
    <script src="JS/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Racuni</h1>
    <table id="transactionTable">
        <thead>
            <tr>
                <th>Broj Racuna</th>
                <th>Stanje</th>
            </tr>
        </thead>
        <tbody>
        <% foreach(System.Data.DataRow row in OnlineBanking_Web.Metode.RacuniDtbl().Rows)
        { %>
        <tr>
            <td><%= row["Broj_Racuna"] %></td>
            <td><%= row["Stanje"] %></td>
        </tr>
        <% } %>
        </tbody>
    </table>
    <div class="button-container">
        <button class="btnKreirajRacun" onserverclick="Unnamed_ServerClick" runat="server">Kreiraj Racun</button>
    </div>
</asp:Content>
