<%@ Page Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="CreditCalculator.Web.Areas.Bank.Request" %>

<asp:Content ContentPlaceHolderID="BankContent" runat="server">
    <div class="bahk-user-requests-wrapper">
        <div class="user-credit-requests-title-wrapper">
            <span class="user-credit-requests-title-text">Credits</span>
        </div>
        <div class="bahk-user-requests-table-wrapper">
            <div class="credit-table-filter">
                <table>
                    <tr>
                        <td>Filter (Status)<span id="creditFilterSpan"></span></td>
                    </tr>
                </table>
                <br />
            </div>
            <table id="bahk-user-credit-requests-table" class="display">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>User Id</th>
                        <th>Get Money</th>
                        <th>Back Money</th>
                        <th>Bank Name</th>
                        <th>Request Status</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="creditRequestsSection" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="requests-table-creation-date">
                                    <%#  DataBinder.Eval(Container.DataItem, "CreationDate", "{0:d/M/yyyy hh:mm tt}")%>
                                </td>
                                <td class="requests-table-user-id-column">
                                    <div class="credit-requests-table-user-id-div">
                                        <%#  DataBinder.Eval(Container.DataItem, "UserId")%>
                                    </div>
                                </td>
                                <td class="requests-table-get-money">
                                    <%#  DataBinder.Eval(Container.DataItem, "GetMoney")%>
                                </td>
                                <td class="requests-table-back-money">
                                    <%#  DataBinder.Eval(Container.DataItem, "BackMoney")%>
                                </td>
                                <td class="requests-table-bank-name">
                                    <%#  DataBinder.Eval(Container.DataItem, "BankName")%>
                                </td>
                                <td class="requests-table-status">
                                    <%#  DataBinder.Eval(Container.DataItem, "Status")%>
                                </td>
                                <td class="credit-requests-table-action-buttons" id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" data-actionname="CreditDecisionRequests">
                                    <asp:Button type="submit" name="action" OnClientClick="return false;" UseSubmitBehavior="false" runat="server" CssClass="SelectDecisionRequests btn waves-effect waves-light" meta:resourcekey="CreditApproveLabelResource" Text='Approve' Visible='<%# Eval("Status").ToString()=="Waiting" %>'></asp:Button>
                                    <asp:Button type="submit" name="action" OnClientClick="return false;" UseSubmitBehavior="false" runat="server" CssClass="SelectDecisionRequests btn waves-effect waves-light" meta:resourcekey="CreditDeclineLabelResource" Text='Decline' Visible='<%# Eval("Status").ToString()=="Waiting" %>'></asp:Button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="user-deposit-requests-title-wrapper">
            <span class="user-deposit-requests-title-text">Deposits</span>
        </div>
        <div class="bahk-user-requests-table-wrapper">
            <div class="deposit-table-filter">
                <table style="width: 120px;">
                    <tr>
                        <td style="width: 50%;">Filter (Status)<span id="depositFilterSpan"></span></td>
                    </tr>
                </table>
                <br />
            </div>
            <table id="bahk-user-deposit-requests-table" class="display">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>User Id</th>
                        <th>Put Money</th>
                        <th>Back Money</th>
                        <th>Bank Name</th>
                        <th>Request Status</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="depositRequestsSection" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="requests-table-creation-date">
                                    <%#  DataBinder.Eval(Container.DataItem, "CreationDate", "{0:d/M/yyyy hh:mm tt}")%>          
                                </td>
                                <td class="requests-table-user-id-column">
                                    <div class="deposits-requests-table-user-id-div">
                                        <%#  DataBinder.Eval(Container.DataItem, "UserId")%>
                                    </div>
                                </td>
                                <td class="requests-table-get-money">
                                    <%#  DataBinder.Eval(Container.DataItem, "PutMoney")%>
                                </td>
                                <td class="requests-table-back-money">
                                    <%#  DataBinder.Eval(Container.DataItem, "BackMoney")%>
                                </td>
                                <td class="requests-table-bank-name">
                                    <%#  DataBinder.Eval(Container.DataItem, "BankName")%>
                                </td>
                                <td class="requests-table-status">
                                    <%#  DataBinder.Eval(Container.DataItem, "Status")%>
                                </td>

                                <td class="deposit-requests-table-action-buttons" id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" data-actionname="DepositDecisionRequests">
                                    <asp:Button type="submit" name="action" OnClientClick="return false;" UseSubmitBehavior="false" runat="server" CssClass="SelectDecisionRequests btn waves-effect waves-light" meta:resourcekey="DepositApproveLabelResource" Text='Approve' Visible='<%# Eval("Status").ToString()=="Waiting" %>'></asp:Button>
                                    <asp:Button type="submit" name="action" OnClientClick="return false;" UseSubmitBehavior="false" runat="server" CssClass="SelectDecisionRequests btn waves-effect waves-light" meta:resourcekey="DepositDeclineLabelResource" Text='Decline' Visible='<%# Eval("Status").ToString()=="Waiting" %>'></asp:Button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
<%--    <button data-target="declineRequestModal" class="btn modal-trigger">Modal</button>--%>
    <div id="declineRequestModal" class="modal">
        <asp:Label ID="hiddenRequestId" runat="server" CssClass="hidden" />
        <asp:Label ID="hiddenStatus" runat="server" CssClass="hidden" />
        <asp:Label ID="hiddenActionName" runat="server" CssClass="hidden" />
        <div class="modal-content-wrapper">
            <div class="modal-content">
                <div class="modal-title-wrapper">
                    <span class="modal-title modal-title-text">Decline Description :</span>
                </div>
                <asp:TextBox runat="server" ID="declineRequestDescription"></asp:TextBox>
            </div>
            <div class="modal-footer">
                <button data-target="declineRequestModal" type="button" class="btn btn-primary" onclick="SendDecisionRequests()">Send</button>
                <button type="button" class="btn modal-close btn-primary" data-dismiss="modal">Cancel</button>
            </div>
        </div>
    </div>
    <script src="../../Scripts/Bank/sendRequests.js"></script>
</asp:Content>


