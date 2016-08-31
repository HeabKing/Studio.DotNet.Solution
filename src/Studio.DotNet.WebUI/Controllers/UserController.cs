using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Studio.DotNet.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IBll.IUserBll _bll;

        public UserController(IBll.IUserBll bll)
        {
            _bll = bll;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public Task<IActionResult> RegisterAsync(Model.RegisterViewModel model)
        {
			return null;

        }
    }
}
