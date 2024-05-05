<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Transakcije.aspx.cs" Inherits="OnlineBanking_Web.Transakcije" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/StyleSheetTransakcije.css"/>
    <script src="JS/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transakcije</h1>
    <table id="transactionTable">
        <thead>
            <tr>
                <th>Iznos</th>
                <th>Vreme</th>
                <th>Broj racuna primaoca</th>
                <th>Broj racuna platioca</th>
            </tr>
        </thead>
        <tbody>
        <% foreach(System.Data.DataRow row in OnlineBanking_Web.Metode.TransakcijeDtbl().Rows)
           { %>
        <tr>
            <td><%= row["Iznos"] %></td>
            <td><%= row["Vreme"] %></td>
            <td><%= row["Broj_Racuna_Primaoca"] %></td>
            <td><%= row["Broj_Racuna_Platioca"] %></td>
        </tr>
        <% } %>
    </tbody>
    </table>
</asp:Content>
