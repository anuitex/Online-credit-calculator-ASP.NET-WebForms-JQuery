<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AvailableBanks.aspx.cs" Inherits="CreditCalculator.Web.Areas.User.AvailableBanks" %>

<asp:Content ID="userCalculator" ContentPlaceHolderID="UserContent" runat="server">
    <div class="user-body-content-wrapper">
        <div class="available-banks-main-title-wrapper">
            <div class="available-banks-title-wrapper">
                <span class="available-banks-title-text">Available Banks</span>
            </div>
        </div>
        <div class="history-credit-request-wrapper">
            <table id="user-available-banks-table" class="available-banks-table display">
                <thead>
                    <tr>
                        <th></th>
                        <th>Name </th>
                        <th>Country </th>
                        <th>Address </th>
                        <th>Information </th>
                        <th>PhoneNumber </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="availableBanksList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td class="available-banks-bank-name">
                                    <a class="bank-refference" data-bankid='<%#  DataBinder.Eval(Container.DataItem, "Id")%>' runat="server"><%#  DataBinder.Eval(Container.DataItem, "Name")%></a>
                                </td>
                                <td class="available-banks-bank-country">
                                    <%#  DataBinder.Eval(Container.DataItem, "Country")%>
                                </td>
                                <td class="available-banks-bank-address">
                                    <%#  DataBinder.Eval(Container.DataItem, "Address")%>
                                </td>
                                <td class="available-banks-bank-information">
                                    <%#  DataBinder.Eval(Container.DataItem, "Information")%>
                                </td>
                                <td class="available-banks-bank-phone-number">
                                    <%#  DataBinder.Eval(Container.DataItem, "PhoneNumber")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <script src="../../Scripts/User/passDataInUrl.js"></script>
</asp:Content>
