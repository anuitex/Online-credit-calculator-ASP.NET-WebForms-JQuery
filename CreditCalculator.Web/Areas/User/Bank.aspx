<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="CreditCalculator.Web.Areas.User.Bank" %>

<asp:Content ID="bankIndex" class="bankIndex" ContentPlaceHolderID="UserContent" runat="server">
    <div class="user-content-main-wrapper">
        <div class="user-content-services-wrapper">
            <div class="user-bank-home-title-wrapper">
                <div class="user-bank-home-title-text">
                    <asp:Label ID="bankNameLabel" class="bankName" runat="server" meta:resourcekey="bankNameLabelResource"></asp:Label>
                </div>
            </div>
            <div class="user-bank-home-content-wrapper">
                <div class="bank-info-wrapper">
                    <div class="bank-services-content-wrapper">
                        <div class="bank-services-wrapper">
                            <div class="bank-services-title-wrapper">
                                <span class="bank-services-title-text">Services</span>
                            </div>
                        </div>
                        <div class="bank-services-menu-elements-wrapper">
                            <div class="wrapper">
                                <div class="toggle toggle--active">
                                    <ul class="toggle-menu">
                                        <li>
                                            <a class="move-with-parameters-refference" data-service-name="CreditRequest" href="javascript:__doPostBack('ctl00$BankContent$ctl00','')" style="font-size: 14pt;">Credit</a>
                                        </li>
                                        <li>
                                            <a class="move-with-parameters-refference" data-service-name="DepositRequest" href="javascript:__doPostBack('ctl00$BankContent$ctl01','')" style="font-size: 14pt;">Deposit</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
