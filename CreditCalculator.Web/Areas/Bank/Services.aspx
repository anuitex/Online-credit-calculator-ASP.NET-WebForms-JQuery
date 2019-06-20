<%@ Page Language="C#" MasterPageFile="~/Bank.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="CreditCalculator.Web.Areas.Bank.Services" %>

<asp:Content ID="cervicesIndex" class="bankIndex" ContentPlaceHolderID="BankContent" runat="server">
    <div class="bank-services-main-wrapper">
        <link href="../../Content/css/materialBootstrap/bootstrap-material-design.min.css" rel="stylesheet" />
        <div class="bank-services-content-wrapper">
            <div class="bank-services-wrapper">
                <div class="bank-services-title-wrapper">
                    <span class="bank-services-title-text">Services</span>
                </div>
                <div class="bank-services-menu-elements-wrapper">
                    <div class="wrapper">
                        <div class="toggle">
                            <ul class="toggle-menu">
                                <li>
                                    <asp:LinkButton
                                        Text="Credit"
                                        Font-Size="14pt"
                                        OnCommand="ChangeService"
                                        CommandArgument="Credit"
                                        runat="server" />
                                </li>
                                <li>
                                    <asp:LinkButton
                                        Text="Deposit"
                                        Font-Size="14pt"
                                        OnCommand="ChangeService"
                                        CommandArgument="Deposit"
                                        runat="server" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <asp:MultiView ID="ServicesMenuWrapper" runat="Server">
                        <asp:View ID="CreditView" runat="server">
                            <div class="service-title-wrapper">
                                <button type="button" class="btn waves-effect waves-light" onclick="showAddPropositionModal();">Add</button>
                                <span class="service-title-text">Propositions</span>
                            </div>
                            <div class="credit-propositions-table-wrapper">
                                <table id="credit-propositions-table" class="display">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th class="hidden-field"></th>
                                            <th>Date</th>
                                            <th>Title</th>
                                            <th>Sub Title</th>
                                            <th>Min Bet Credit</th>
                                            <th>Max Bet Credit</th>
                                            <th>Min Bet Deposit</th>
                                            <th>Max Bet Deposit</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="creditPropositionsSection" runat="server">
                                            <ItemTemplate>
                                                <tr data-proposition-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>">
                                                    <td></td>
                                                    <td class="hidden-field propositions-table-bank-id"><%#  DataBinder.Eval(Container.DataItem, "BankId")%></td>
                                                    <td class="propositions-table-creation-date">
                                                        <%#  DataBinder.Eval(Container.DataItem, "CreationDate", "{0:d/M/yyyy hh:mm tt}")%>
                                                    </td>
                                                    <td class="propositions-table-title">
                                                        <%#  DataBinder.Eval(Container.DataItem, "Title")%>
                                                    </td>
                                                    <td class="propositions-table-sub-title">
                                                        <%#  DataBinder.Eval(Container.DataItem, "SubTitle")%>
                                                    </td>
                                                    <td class="propositions-table-credit-min-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MinBetCredit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="propositions-table-credit-max-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MaxBetCredit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="propositions-table-deposit-min-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MinBetDeposit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="propositions-table-deposit-max-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MaxBetDeposit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="credit-propositions-table-action-buttons">
                                                        <button type="button" class="btn waves-effect waves-light" id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" onclick="editPropositionModal(this);">Edit</button>
                                                        <button type="button" class="btn waves-effect waves-light delete" data-proposition-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" onclick="deletePropositionModal(this);">Delete</button>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="DepositView" runat="server">
                            <div class="service-title-wrapper">
                                <button type="button" class="btn waves-effect waves-light" onclick="showAddPropositionModal();">Add</button>
                                <span class="service-title-text">Propositions</span>
                            </div>
                            <div class="deposit-propositions-table-wrapper">
                                <table id="deposit-propositions-table" class="display">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th class="hidden-field"></th>
                                            <th>Date</th>
                                            <th>Title</th>
                                            <th>Sub Title</th>
                                            <th>Min Bet Credit</th>
                                            <th>Max Bet Credit</th>
                                            <th>Min Bet Deposit</th>
                                            <th>Max Bet Deposit</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="depositPropositionsSection" runat="server">
                                            <ItemTemplate>
                                                <tr data-proposition-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>">
                                                    <td></td>
                                                    <td class="hidden-field propositions-table-bank-id"><%#  DataBinder.Eval(Container.DataItem, "BankId")%></td>
                                                    <td class="propositions-table-creation-date">
                                                        <%#  DataBinder.Eval(Container.DataItem, "CreationDate", "{0:d/M/yyyy hh:mm tt}")%>
                                                    </td>
                                                    <td class="propositions-table-title">
                                                        <%#  DataBinder.Eval(Container.DataItem, "Title")%>
                                                    </td>
                                                    <td class="propositions-table-sub-title">
                                                        <%#  DataBinder.Eval(Container.DataItem, "SubTitle")%>
                                                    </td>
                                                    <td class="propositions-table-credit-min-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MinBetCredit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="propositions-table-credit-max-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MaxBetCredit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="propositions-table-deposit-min-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MinBetDeposit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="propositions-table-deposit-max-bet">
                                                        <span class="value"><%#  DataBinder.Eval(Container.DataItem, "MaxBetDeposit")%></span>
                                                        <span>%</span>
                                                    </td>
                                                    <td class="deposit-propositions-table-action-buttons">
                                                        <button type="button" class="btn waves-effect waves-light" id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" onclick="editPropositionModal(this);">Edit</button>
                                                        <button type="button" class="btn waves-effect waves-light delete" onclick="deletePropositionModal(this);">Delete</button>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
        </div>
    </div>
    <div id="editServicePropositionModal" class="modal">
        <div class="card">
            <asp:Label ID="hiddenPropositionId" runat="server" CssClass="hidden" />
            <asp:Label ID="hiddenBankId" runat="server" CssClass="hidden" />
            <div class="modal-content-wrapper">
                <div class="modal-content">
                    <div class="modal-title-wrapper">
                        <span class="modal-title modal-title-text">Edit Proposition</span>
                    </div>
                    <div class="input-group">
                        <label for="dataTextBox">Data :</label>
                        <input id="dataTextBox" type="text" placeholder="Data" disabled>
                    </div>
                    <div class="input-group">
                        <label for="titleTextBox">Title :</label>
                        <asp:DropDownList ID="editPropositionTitleDropDown" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="Credit" Value="Credit" />
                            <asp:ListItem Text="Deposit" Value="Deposit" />
                        </asp:DropDownList>
                    </div>
                    <div class="input-group">
                        <label for="subTitleTextBox">Sub Title :</label>
                        <input id="subTitleTextBox" type="text" placeholder="Sub Title">
                    </div>
                    <div class="input-group">
                        <label for="minBetCreditTextBox">Min Bet Credit :</label>
                        <input id="minBetCreditTextBox" type="text" placeholder="Min Bet Credit">
                    </div>
                    <div class="input-group">
                        <label for="maxBetCreditTextBox">Max Bet Credit :</label>
                        <input id="maxBetCreditTextBox" type="text" placeholder="Max Bet Credit">
                    </div>
                    <div class="input-group">
                        <label for="minBetDepositTextBox">Min Bet Deposit :</label>
                        <input id="minBetDepositTextBox" type="text" placeholder="Min Bet Deposit">
                    </div>
                    <div class="input-group bottom-element">
                        <label for="maxBetDepositTextBox">Max Bet Deposit :</label>
                        <input id="maxBetDepositTextBox" type="text" placeholder="Max Bet Deposit">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn modal-close btn-primary" data-dismiss="modal">Cancel</button>
                    <button data-target="declineRequestModal" type="button" class="btn btn-primary" onclick="sendUpdatePropositionData()">Send</button>
                </div>
            </div>
        </div>
    </div>
    <div id="addServicePropositionModal" class="modal">
        <div class="card">
            <asp:Label ID="addServicePropositionHiddenBankId" runat="server" CssClass="hidden" />
            <div class="modal-content-wrapper">
                <div class="modal-content">
                    <div class="modal-title-wrapper">
                        <span class="modal-title modal-title-text">Add Proposition</span>
                    </div>
                    <div class="input-group">
                        <label for="addPropositionTitleTextBox">Title :</label>
                        <asp:DropDownList ID="addPropositionTitleDropDown" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="--Select--" Value="" Selected="True" />
                            <asp:ListItem Text="Credit" Value="Credit" />
                            <asp:ListItem Text="Deposit" Value="Deposit" />
                        </asp:DropDownList>
                    </div>
                    <div class="input-group">
                        <label for="addPropositionSubTitleTextBox">Sub Title :</label>
                        <input id="addPropositionSubTitleTextBox" type="text" placeholder="Sub Title">
                    </div>
                    <div class="input-group">
                        <label for="addPropositionMinBetCreditTextBox">Min Bet Credit :</label>
                        <input id="addPropositionMinBetCreditTextBox" type="text" placeholder="Min Bet Credit">
                    </div>
                    <div class="input-group">
                        <label for="addPropositionMaxBetCreditTextBox">Max Bet Credit :</label>
                        <input id="addPropositionMaxBetCreditTextBox" type="text" placeholder="Max Bet Credit">
                    </div>
                    <div class="input-group">
                        <label for="addPropositionMinBetDepositTextBox">Min Bet Deposit :</label>
                        <input id="addPropositionMinBetDepositTextBox" type="text" placeholder="Min Bet Deposit">
                    </div>
                    <div class="input-group bottom-element">
                        <label for="addPropositionMaxBetDepositTextBox">Max Bet Deposit :</label>
                        <input id="addPropositionMaxBetDepositTextBox" type="text" placeholder="Max Bet Deposit">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn modal-close btn-primary" data-dismiss="modal" onclick="closeAddPropositionModal()">Cancel</button>
                    <button type="button" class="btn btn-primary" onclick="addProposition()">Send</button>
                </div>
            </div>
        </div>
    </div>
    <div id="deleteServicePropositionModal" class="modal">
        <div class="card">
            <asp:Label ID="hiddenDeletePropositionId" runat="server" CssClass="hidden" />

            <div class="modal-content-wrapper">
                <div class="modal-content">
                    <div class="modal-title-wrapper">
                        <span class="modal-title modal-title-text">Do you want to delete this Proposition ?</span>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn modal-close btn-primary" data-dismiss="modal" onclick="closeAddPropositionModal()">Cancel</button>
                    <button type="button" class="btn btn-primary" onclick="confirmDeleteProposition()">Delete</button>
                </div>
            </div>
        </div>
    </div>


    <script src="../../Scripts/Bank/bankPropositionsTables.js"></script>
    <script src="../../Scripts/Bank/servicePropositionActions.js"></script>
</asp:Content>
