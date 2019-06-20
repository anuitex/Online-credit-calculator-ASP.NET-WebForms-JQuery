<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DepositRequest.aspx.cs" Inherits="CreditCalculator.Web.Areas.User.Deposit" %>

<asp:Content ID="UserDepositContent" ContentPlaceHolderID="UserContent" runat="server">
    <div class="user-deposit-requests-wrapper">
        <a runat="server" class="hiddenUserId" hidden><%: Context.User.Identity.GetUserId()  %> </a>
        <div class="user-calculator">
            <div class="calculator-wrapper">
                <div class="user-info-wrapper hidden-file">
                    <asp:Label ID="bankName" class="bank-name" runat="server" meta:resourcekey="bankNameLabelResource"></asp:Label>
                    <asp:Label ID="bankId" class="bank-id" runat="server" meta:resourcekey="bankIdLabelResource"></asp:Label>
                </div>
                <div class="deposit-title-wrapper mx-2">
                    <span class="page-title-text">Deposit</span>
                </div>
                <div id="sendDepositWrapper">
                    <div class="deposit-calculator-currency">
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <button type="button" class="btn btn-secondary" data-currency="euro" data-class-currency="fa-euro-sign" title="EURO" onclick="selectCurrency(this);">
                                <i class="fas fa-euro-sign currency-icon"></i>
                            </button>
                            <button type="button" class="btn btn-secondary" data-currency="dollar" data-class-currency="fa-dollar-sign" title="USA" onclick="selectCurrency(this);">
                                <i class="fas fa-dollar-sign currency-icon"></i>
                            </button>
                            <button type="button" class="btn btn-secondary" data-currency="hryvnia" data-class-currency="fa-hryvnia" title="UA" onclick="selectCurrency(this);">
                                <i class="fas fas fa-hryvnia currency-icon"></i>
                            </button>
                        </div>
                    </div>
                    <div class="deposit-calculator-content">
                        <div class="calculator-compute-deposit-wrapper">
                        </div>
                        <div class="calculator-compute">
                            <div class="money-label">
                                <span>Money quantity :</span>
                            </div>
                            <div class="selected-money-quantity">
                                <input type="range" value="0" step="1" min="0" max="10000">
                                <br>
                                <br>
                                <h2 style="display: inline-block; margin-bottom: 50px;"></h2>
                                <output class="selected-money-quantity-output" style="display: inline-block"><span class="selected-money-quantity-output-value">0</span>,00 <span class="selected-currency-span"><i class=""></i></span></output>
                            </div>
                            <div class="month-label">
                                <span>Month quantity :</span>
                            </div>
                            <div class="selected-month-quantity">
                                <input type="range" value="0" step="1" min="0" max="48">
                                <br>
                                <br>
                                <h2 style="display: inline-block; margin-bottom: 50px;"></h2>
                                <output class="selected-month-quantity-output" style="display: inline-block"><span class="selected-month-quantity-output-span">0</span> month</output>
                            </div>
                        </div>
                        <div class="calculator-result">
                            <div class="calculator-result-title">
                                <span>Result :</span>
                            </div>
                            <div class="money-rate-wrapper">
                                <span class="show-money-rate-title-span">Money Rate :  <span class="show-money-rate-value-span">0</span> %</span>
                            </div>
                            <div class="money-get-quantity-wrapper">
                                <span class="money-get-quantity">Money Get :  <span class="show-money-span">0 </span>,00<span class="selected-currency-span"> <i class=""></i></span></span>
                            </div>
                            <div class="money-back-quantity-wrapper">
                                <span class="money-back-quantity">Money Back : <span class="show-back-money-span">0</span>,00<span class="selected-currency-span"> <i class=""></i></span></span>
                            </div>
                        </div>
                    </div>
                    <div class="send-order-button-wrapper">
                        <button type="submit" class="send-order-button" onclick="sendOrder();">Send Order</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../../Scripts/User/DepositCalculator.js"></script>
</asp:Content>
