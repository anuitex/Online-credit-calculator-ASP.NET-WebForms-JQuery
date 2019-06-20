<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CreditCalculator.Web.Areas.User.Home" %>

<asp:Content ID="userHome" ContentPlaceHolderID="UserContent" runat="server">
    <div class="user-content-main-wrapper">
        <div class="user-content-wrapper">
            <div class="history-main-title-wrapper">
                <div class="history-main-wrapper">
                    <span class="history-main-title-text">History Requests</span>
                </div>
            </div>
            <div class="history-credit-request-wrapper">
                <div class="history-credit-request-title-wrapper">
                    <span class="history-credit-request-title-text" style="font-size: 20px; font-weight: bold;">Credits :</span>
                </div>
                <div class="user-credit-requests-filter-wrapper">
                    <div class="user-credit-requests-filter">
                        <table>
                            <tr>
                                <td>Filter (Status)<span id="creditFilterSpan"></span></td>
                            </tr>
                        </table>
                        <br />
                    </div>
                </div>
                <table id="user-credit-requests-table" class="credit-requests-table display">
                    <thead>
                        <tr class="requests-table-head">
                            <th>Creation Date</th>
                            <th>Get Money</th>
                            <th>Back Money</th>
                            <th>Bank Name</th>
                            <th>Request Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="allCreditRequestsSection" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "CreationDate")%>
                                    </td>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "GetMoney")%>
                                    </td>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "BackMoney")%>
                                    </td>

                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "BankName")%>
                                    </td>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "Status")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="history-deposit-request-wrapper">
                <div class="history-deposit-request-title-wrapper">
                    <span class="history-deposit-request-title-text" style="font-size: 20px; font-weight: bold;">Deposits :</span>
                </div>
                <div class="user-deposit-requests-filter-wrapper">

                    <div class="user-deposit-requests-filter">
                        <table>
                            <tr>
                                <td>Filter (Status)<span id="depositFilterSpan"></span></td>
                            </tr>
                        </table>
                        <br />
                    </div>
                </div>
                <table id="user-deposit-requests-table" class="deposit-requests-table display">
                    <thead>
                        <tr class="requests-table-head">
                            <th>Creation Date</th>
                            <th>Put Money</th>
                            <th>Back Money</th>
                            <th>Bank Name</th>
                            <th>Request Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="allDepositRequestsSection" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "CreationDate")%>
                                    </td>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "PutMoney")%>
                                    </td>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "BackMoney")%>
                                    </td>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "BankName")%>
                                    </td>
                                    <td>
                                        <%#  DataBinder.Eval(Container.DataItem, "Status")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

