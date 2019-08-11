using AppMyVet.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Veterinary.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public ActionResult Login()
        {

            return View();
        }
    }
}
