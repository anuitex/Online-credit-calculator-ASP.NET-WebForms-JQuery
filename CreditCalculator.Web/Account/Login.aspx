<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CreditCalculator.Web.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="login-page-main-wrapper">
        <div class="login-page-wrapper">

            <div class="row">
                <div class="col-md-8 middle-wrapper">
                    <section id="loginForm">
                        <div class="form-horizontal">
                            <div class="form-horizontal-login">
                                <div class="form-title">
                                    <p class="big-title"><%: Title %>.</p>
                                    <p class="small-title">Sign In to your account</p>
                                </div>
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
                                                    <i class="fa fa-key" aria-hidden="true"></i>
                                                </div>
                                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password" />
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                                        </div>
                                    </div>
                                </div>
                                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                    <p class="text-danger">
                                        <asp:Literal runat="server" ID="FailureText" />
                                    </p>
                                </asp:PlaceHolder>
                                <div class="login-page-action-wrapper">
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10 middle-wrapper">
                                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10 middle-wrapper">
                                            <div class="checkbox">
                                                <asp:CheckBox runat="server" ID="RememberMe" disable="false" />
                                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="regester-wrapper">
                                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                        <p>
                        </p>
                        <p>
                            <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                            --%>
                        </p>
                    </section>
                </div>

                <%--        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>--%>
            </div>


        </div>

    </div>
</asp:Content>
