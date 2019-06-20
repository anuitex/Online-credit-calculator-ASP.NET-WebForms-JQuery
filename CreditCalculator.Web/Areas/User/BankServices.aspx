<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="BankServices.aspx.cs" Inherits="CreditCalculator.Web.Areas.User.BankServices" %>

<asp:Content ID="cervicesIndex" class="bankIndex" ContentPlaceHolderID="UserContent" runat="server">
    <div class="bank-top-menu-wrapper">
        <ul class="nav nav-tabs bg-dark">
            <li data-flag-menu="Home" class="nav-item">
                <a data-service-name="Bank" class="nav-link move-with-parameters-refference" href="#">Home <span class="sr-only">(current)</span></a>
            </li>
            <li data-flag-menu="Services" class="nav-item">
                <a class="nav-link services-refference" href="#">Services</a>
            </li>
            <li data-flag-menu="Pricing" class="nav-item">
                <a class="nav-link" href="#">Pricing</a>
            </li>
            <li data-flag-menu="AboutUs" class="nav-item">
                <a class="nav-link" href="#">About Us</a>
            </li>
        </ul>
    </div>
    <div class="bank-services-wrapper">
        <asp:Label ID="hiddenBankName" runat="server" />
        <br />
        <asp:Label ID="hiddenBankId" runat="server" />
    </div>
    <div class="bank-services-title-wrapper">
        <span class="bank-services-title-text">Services</span>
    </div>
    <div class="bank-services-menu-wrapper">
        <div class="bank-services-menu">
            <ul>
                <li><a class="move-with-parameters-refference" data-service-name="CreditRequest" href="#">CREDIT</a></li>
                <li><a class="move-with-parameters-refference" data-service-name="DepositRequest" href="#">DEPOSIT</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
