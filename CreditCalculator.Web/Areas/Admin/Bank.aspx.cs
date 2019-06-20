using CreditCalculator.Services.Admin;
using CreditCalculator.ViewModels.Admin;
using DAL.Identity;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreditCalculator.Web.Areas.Admin
{
    public partial class Bank : Page
    {
        private static BankService _bankService;
        private static UserService _userService;

        public Bank()
        {
            _bankService = new BankService();
            _userService = new UserService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!authenticationManager.User.Identity.IsAuthenticated)
            {
                IdentityHelper.RedirectToReturnUrl("/Account/Login", Response);
            }

            bankAdminDropDown.Items.Clear();

            var banks = _bankService.GetAllBanks();
            var bankAdmins = _userService.GetAvailableBankAdmins();

            int index = 0;

            foreach (var elem in bankAdmins)
            {
                bankAdminDropDown.Items.Insert(index, new ListItem(elem.UserName, elem.Id.ToString()));
                index++;
            }

            adminBanksSection.DataSource = banks;
            adminBanksSection.DataBind();
        }

        [System.Web.Services.WebMethod]
        public static void AddNewBank(AddBankViewModel model)
        {
            _bankService.AddBank(model);
            _userService.ChangeIsHasBankStatus(model.AdminId, true);
        }


        [System.Web.Services.WebMethod]
        public static string UpdateBank(UpdateBankViewModel model)
        {
            _bankService.UpdateBank(model);

            return "Ok";
        }

        [System.Web.Services.WebMethod]
        public static string DeleteBank(string bankId, string adminId)
        {
            _bankService.DeletePropositionsByBankId(bankId);
            _bankService.DeleteCreditsByBankId(bankId);
            _bankService.DeleteDepositsByBankId(bankId);

            _bankService.DeleteBank(bankId);

            _userService.ChangeIsHasBankStatus(adminId, false);

            return "Ok";
        }

    }
}