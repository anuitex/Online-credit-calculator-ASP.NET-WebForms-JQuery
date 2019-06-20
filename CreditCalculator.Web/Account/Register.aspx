<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CreditCalculator.Web.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="register-page-main-wrapper">
        <div class="register-page-wrapper">
            <div class="register-page-form-wrapper">
                <div class="form-title">
                    <p class="big-title"><%: Title %>.</p>
                    <p>Create a new account</p>
                </div>
                <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
                </p>
                <div class="form-horizontal">
                    <div class="form-horizontal-register">
                        <asp:ValidationSummary runat="server" CssClass="text-danger" />
                        <div class="form-text-boxes">
                            <div class="form-group">
                                <div class="col-md-10 middle-wrapper">
                                    <div class="text-box-wrapper">
                                        <div class="icon-wrapper">
                                            <i class="fas fa-envelope"></i>
                                        </div>
                                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Email" />
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                        CssClass="text-danger" ErrorMessage="The email field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 middle-wrapper">
                                    <div class="text-box-wrapper">
                                        <div class="icon-wrapper">
                                            <i class="fas fa-envelope"></i>
                                        </div>
                                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password" />
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                        CssClass="text-danger" ErrorMessage="The password field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 middle-wrapper">
                                    <div class="text-box-wrapper">
                                        <div class="icon-wrapper">
                                            <i class="fas fa-envelope"></i>
                                        </div>
                                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm Password" />
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                </div>
                            </div>
                        </div>
                        <div class="form-group-register-button-wrapper">
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10 middle-wrapper">
                                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
