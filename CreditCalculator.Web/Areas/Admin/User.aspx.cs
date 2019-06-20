using CreditCalculator.Configurations;
using CreditCalculator.Services.Admin;
using CreditCalculator.ViewModels.Admin;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;

namespace CreditCalculator.Web.Areas.Admin
{
    [ScriptService]
    public partial class User : Page
    {
        private static UserService _userService;
        private readonly ApplicationDbContext _context;

        public User()
        {
            _userService = new UserService();
            _context = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var allUsers = _userService.GetAllUsers();
            var allRoles = _userService.GetAllRoles(_context);

            if (!IsPostBack)
            {
                userRolesDropDown.DataSource = (allRoles);
                userRolesDropDown.DataBind();
            }

            adminUsersSection.DataSource = allUsers;
            adminUsersSection.DataBind();
        }

        public IdentityResult SendRegistrationData(AddUserViewModel model)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = _userService.CreateUser(manager, signInManager, model);

            return result;
        }

        public void SendUpdateData(UpdateUserViewModel model)
        {
            _userService.UpdateUser(model);
        }

        [System.Web.Services.WebMethod]
        public static IdentityResult AddNewUser(AddUserViewModel model)
        {
            var userClass = new User();
            var result = userClass.SendRegistrationData(model);

            return result;
        }

        [System.Web.Services.WebMethod]
        public static string UpdateUser(UpdateUserViewModel model)
        {
            var userClass = new User();
            userClass.SendUpdateData(model);

            return "Ok";
        }

        [System.Web.Services.WebMethod]
        public static string DeleteUser(string userId)
        {
            var result = _userService.CheckIsHasBankStatus(userId);

            if (result)
            {
                _userService.DeletePropositionsByUserId(userId);

                _userService.DeleteCreditsByUserId(userId);

                _userService.DeleteDepositsByUserId(userId);
            }

            _userService.DeleteUserById(userId);

            return "Ok";
        }
    }
}