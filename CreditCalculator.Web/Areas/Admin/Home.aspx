<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CreditCalculator.Web.Areas.Admin.Home" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="adminPage" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="container admin-calendar">
        <div class="custom-calendar-wrap custom-calendar-full">
            <div class="custom-header clearfix">
                <div class="admin-calendar-top-data-wrapper">
                    <h2>Flexible Calendar</h2>
                    <div class="custom-month-year">
                        <nav class="admin-calendar-top-right-data">
                            <div class="admin-calendar-top-text">
                                <h6 id="custom-month" class="custom-month"></h6>
                                <h6 id="custom-year" class="custom-year"></h6>
                            </div>
                            <div class="admin-calendar-top-buttons">
                                <span id="custom-prev" class="custom-prev"></span>
                                <span id="custom-next" class="custom-next"></span>
                                <span id="custom-current" class="custom-current" title="Got to current date"></span>
                            </div>
                        </nav>
                    </div>
                </div>
            </div>
            <div id="calendar" class="fc-calendar-container"></div>
        </div>
    </div>
    <script src="../../Scripts/Admin/calendar.js"></script>
</asp:Content>
