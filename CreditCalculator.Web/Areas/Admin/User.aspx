<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="CreditCalculator.Web.Areas.Admin.User" %>

<asp:Content ID="adminPage" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="admin-users-main-wrapper">
        <div class="admin-add-new-user-wrapper">
            <div id="modal-container">
                <div class="modal-background">
                    <div class="modal">
                        <div class="admin-add-new-user-title-wrapper">
                            <h2>New User</h2>
                        </div>
                        <div class="admin-add-new-user-info-wrapper">
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="firstNameTextBox" type="text" class="validate">
                                    <label for="firstNameTextBox">First Name</label>
                                </div>
                                <div class="input-field col s6">
                                    <input id="lastNameTextBox" type="text" class="validate">
                                    <label for="lastNameTextBox">Last Name</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s12 user-email-wrapper">
                                    <div class="input-field inline input-field-email">
                                        <input id="emailTextBox" type="email" class="validate">
                                        <label for="emailTextBox">Email</label>
                                        <span class="helper-text" data-error="Invalid" data-success="Ok">Validation</span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="passportSeriesTextBox" type="text" class="validate">
                                    <label for="passportSeriesTextBox">Passport Series :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="passportNumberTextBox" type="text" class="validate">
                                    <label for="passportNumberTextBox">Passport Number :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="addressTextBox" type="text" class="validate">
                                    <label for="addressTextBox">Address :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <asp:DropDownList CssClass="userRolesDropDown" ID="userRolesDropDown" runat="server" AutoPostBack="False"></asp:DropDownList>
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
                                    <input id="passwordTextBox" type="password" class="validate passwordTextBox">
                                    <label for="passwordTextBox">Password</label>
                                </div>
                                <div class="input-field col s6">
                                    <input id="passwordConfirmTextBox" class="passwordConfirmTextBox" type="password">
                                    <label for="passwordConfirmTextBox" data-error="Password not match" data-success="Password Match">Password (Confirm)</label>
                                </div>
                            </div>
                            <div class="admin-add-new-user-buttons-wrapper">
                                <asp:Button CssClass="admin-add-new-user-button-cansel" runat="server" Text="Cancel" OnClientClick="return false;" UseSubmitBehavior="false" />
                                <asp:Button CssClass="admin-add-new-user-button-register" runat="server" Text="Register" OnClientClick="return false;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="buttons-wrapper">
                <button id="one" type="button" class="admin-add-new-user-button button">ADD NEW</button>
            </div>
        </div>
        <div class="admin-edit-user-wrapper">
            <div id="edit-user-modal-container">
                <div class="modal-background">
                    <div class="modal">
                        <asp:Label ID="hiddenUserId" runat="server" CssClass="hidden" />
                        <div class="edit-user-title-wrapper">
                            <h2>Edit User</h2>
                        </div>
                        <div class="edit-user-info-wrapper">
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editUserFirstNameTextBox" type="text" class="validate">
                                    <label for="editUserFirstNameTextBox" class="activeinput">First Name</label>
                                </div>
                                <div class="input-field col s6">
                                    <input id="editUserLastNameTextBox" type="text" class="validate">
                                    <label for="editUserLastNameTextBox" class="activeinput">Last Name</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s12 user-email-wrapper">
                                    <div class="input-field inline input-field-email">
                                        <input id="editUserEmailTextBox" type="email" class="validate">
                                        <label for="editUserEmailTextBox" class="activeinput">Email</label>
                                        <span class="helper-text" data-error="Invalid" data-success="Ok">Validation</span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editUserPassportSeriesTextBox" type="text" class="validate">
                                    <label for="editUserPassportSeriesTextBox" class="activeinput">Passport Series :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editUserPassportNumberTextBox" type="text" class="validate">
                                    <label for="editUserPassportNumberTextBox" class="activeinput">Passport Number :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editUserAddressTextBox" type="text" class="validate">
                                    <label for="editUserAddressTextBox" class="activeinput">Address :</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="input-field col s6">
                                    <input id="editUserPhoneNumberTextBox" type="text" class="validate">
                                    <label for="editUserPhoneNumberTextBox" class="activeinput">Phone Number :</label>
                                </div>
                            </div>
                            <div class="admin-edit-user-buttons-wrapper">
                                <asp:Button CssClass="admin-edit-user-button-cansel" runat="server" Text="Cancel" OnClientClick="return false;" UseSubmitBehavior="false" />
                                <asp:Button CssClass="admin-edit-user-button-save" runat="server" Text="Save" OnClientClick="return false;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="deleteUserModal" class="modal">
            <div class="card">
                <asp:Label ID="hiddenDeleteUserId" runat="server" CssClass="hidden" />
                <div class="modal-content-wrapper">
                    <div class="modal-content">
                        <div class="modal-title-wrapper">
                            <span class="modal-title modal-title-text">Do you want to delete this User ?</span>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn modal-close btn-primary" data-dismiss="modal" onclick="closeDeleteUserModal()">Cancel</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDeleteUser()">Delete</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="admin-users-content-wrapper">
            <div class="admin-users-table-title-wrapper">
                <span class="admin-users-table-title-text">Users</span>
            </div>
            <table id="admin-users-table" class="display">
                <thead>
                    <tr>
                        <th></th>
                        <th>User</th>
                        <th>Email</th>
                        <th>Creation Date</th>
                        <th>Phone Number</th>
                        <th>Passport Series</th>
                        <th>Passport Number</th>
                        <th>Address</th>
                        <th>Is Admin</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="adminUsersSection" runat="server">
                        <ItemTemplate>
                            <tr data-user-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>">
                                <td></td>
                                <td class="admin-users-name">
                                    <span class="user-first-name">
                                        <%#  DataBinder.Eval(Container.DataItem, "FirstName")%>
                                    </span>
                                    <span class="admin-users-name-separator"></span>
                                    <span class="user-last-name">
                                        <%#  DataBinder.Eval(Container.DataItem, "LastName")%>
                                    </span>
                                </td>
                                <td class="userEmail">
                                    <%#  DataBinder.Eval(Container.DataItem, "Email")%>
                                </td>

                                <td class="userCreationDate">
                                    <%#  DataBinder.Eval(Container.DataItem, "CreationDate")%>
                                </td>
                                <td class="userPhoneNumber">
                                    <%#  DataBinder.Eval(Container.DataItem, "PhoneNumber")%>
                                </td>
                                <td class="userPassportSeries">
                                    <%#  DataBinder.Eval(Container.DataItem, "PassportSeries")%>
                                </td>
                                <td class="userPassportNumber">
                                    <%#  DataBinder.Eval(Container.DataItem, "PassportNumber")%>
                                </td>
                                <td class="userAddress">
                                    <%#  DataBinder.Eval(Container.DataItem, "Address")%>
                                </td>
                                <td class="userIsAdmin">
                                    <%#  DataBinder.Eval(Container.DataItem, "IsAdmin")%>
                                </td>

                                <td class="admin-users-table-action-buttons">
                                    <button type="button" class="btn waves-effect waves-light" data-user-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" onclick="editUserModal(this)">Edit</button>
                                    <button type="button" class="btn waves-effect waves-light delete" data-user-id="<%#  DataBinder.Eval(Container.DataItem, "Id")%>" onclick="deleteUserModal(this);">Delete</button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <script src="../../Scripts/Admin/users-table.js"></script>
</asp:Content>
