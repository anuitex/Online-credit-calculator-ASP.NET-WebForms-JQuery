<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="CreditCalculator.Web.Areas.Admin.Bank" %>

<asp:Content ID="adminBanksPage" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="admin-banks-main-wrapper">
        <div class="admin-add-new-bank-wrapper">
            <div id="modal-container">
                <div class="modal-background">
                    <div class="modal">
                        <div class="admin-add-new-bank-title-wrapper">
                            <h2>New Bank</h2>
                        </div>
                        <div class="admin-add-new-bank-info-wrapper">
                            <div class="row bank-admin-row">
                                <div class="input-field col s6">
                                    <asp:DropDownList ID="bankAdminDropDown" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select--" Value="" Selected="True" />
                                    </asp:DropDownList>
                                    <label for="bankAdminDropDown">Bank Admin :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="emailTextBox" type="text" class="validate">
                                    <label for="emailTextBox">Email :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="nameTextBox" type="text" class="validate">
                                    <label for="nameTextBox">Name :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="informationTextBox" type="text" class="validate">
                                    <label for="informationTextBox">Information :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="phoneNumberTextBox" type="text" class="validate">
                                    <label for="phoneNumberTextBox">Phone Number :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="countryTextBox" type="text" class="validate">
                                    <label for="countryTextBox">Country :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="addressTextBox" type="text" class="validate">
                                    <label for="addressTextBox">Address :</label>
                                </div>
                            </div>
                        </div>
                        <div class="admin-add-new-bank-buttons-wrapper">
                            <asp:Button CssClass="admin-add-new-bank-button-cansel" runat="server" Text="Cancel" OnClientClick="return false;" UseSubmitBehavior="false" />
                            <asp:Button CssClass="admin-add-new-bank-button-register" ID="addBankButton" runat="server" Text="Register" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="buttons-wrapper">
                <button id="one" type="button" class="admin-add-new-bank-button button">ADD NEW</button>
            </div>
        </div>

        <div class="admin-edit-bank-wrapper">
            <div id="edit-bank-modal-container">
                <div class="modal-background">

                    <div class="modal">
                        <asp:Label ID="hiddenBankId" runat="server" CssClass="hidden" />

                        <div class="edit-bank-title-wrapper">
                            <h2>Edit Bank</h2>
                        </div>
                        <div class="edit-bank-info-wrapper">
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editBankNameTextBox" type="text" class="validate">
                                    <label for="editBankNameTextBox">Name :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editBankInformationTextBox" type="text" class="validate">
                                    <label for="editBankInformationTextBox">Information :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editBankPhoneNumberTextBox" type="text" class="validate">
                                    <label for="editBankPhoneNumberTextBox">Phone Number :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editBankCountryTextBox" type="text" class="validate">
                                    <label for="editBankCountryTextBox">Country :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editBankAddressTextBox" type="text" class="validate">
                                    <label for="editBankAddressTextBox">Address :</label>
                                </div>
                            </div>
                        </div>
                        <div class="edit-bank-buttons-wrapper">
                            <asp:Button CssClass="edit-bank-button-cansel" runat="server" Text="Cancel" OnClientClick="return false;" UseSubmitBehavior="false" />
                            <asp:Button CssClass="edit-bank-button-register" runat="server" Text="Register" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="deleteBankModal" class="modal">
            <div class="card">
                <asp:Label ID="hiddenDeleteBankId" runat="server" CssClass="hidden" />
                <asp:Label ID="hiddenDeleteAdminId" runat="server" CssClass="hidden" />

                <div class="modal-content-wrapper">
                    <div class="modal-content">
                        <div class="modal-title-wrapper">
                            <span class="modal-title modal-title-text">Do you want to delete this Bank ?</span>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn modal-close btn-primary" data-dismiss="modal" onclick="closeAddPropositionModal()">Cancel</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDeleteBank()">Send</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="admin-banks-content-wrapper">
            <div class="admin-banks-title-wrapper">
                <span class="admin-banks-title-text" style="margin-left: 300px; margin-top: 200px;">Banks</span>
            </div>
            <table id="admin-banks-table" class="display">
                <thead>
                    <tr>
                        <th></th>
                        <th>Name</th>
                        <th>Information</th>
                        <th>Phone Number</th>
                        <th>Country</th>
                        <th>Address</th>
                        <th>Creation Date</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="adminBanksSection" runat="server">
                        <ItemTemplate>
                            <tr data-bank-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>">
                                <td></td>
                                <td class="bankName">
                                    <%#  DataBinder.Eval(Container.DataItem, "Name")%>
                                </td>
                                <td class="bankInformation">
                                    <%#  DataBinder.Eval(Container.DataItem, "Information")%>
                                </td>
                                <td class="bankPhoneNumber">
                                    <%#  DataBinder.Eval(Container.DataItem, "PhoneNumber")%>
                                </td>
                                <td class="bankCountry">
                                    <%#  DataBinder.Eval(Container.DataItem, "Country")%>
                                </td>
                                <td class="bankAddress">
                                    <%#  DataBinder.Eval(Container.DataItem, "Address")%>
                                </td>
                                <td class="bankCreationDate">
                                    <%#  DataBinder.Eval(Container.DataItem, "CreationDate")%>
                                </td>
                                <td class="admin-banks-table-action-buttons">
                                    <button type="button" class="btn waves-effect waves-light" data-bank-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" onclick="editBankModal(this)">Edit</button>
                                    <button type="button" class="btn waves-effect waves-light delete" data-bank-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" data-admin-id="<%#  DataBinder.Eval(Container.DataItem, "AdminId")%>" onclick="deleteBankModal(this);">Delete</button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

    <script src="../../Scripts/Admin/banks-table.js"></script>
</asp:Content>
