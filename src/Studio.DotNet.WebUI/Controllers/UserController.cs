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
        public async Task<IActionResult> RegisterAsync(Model.RegisterViewModel model)
        {
            bool isOk;
            if (model.Pwd != model.ConfirmPwd)
            {
                isOk = false;
            }
            else
            {
                isOk = await _bll.AddAsync(new Domain.TbUserDto
                {
                    PwdHash = model.Pwd,
                    UserName = model.UserName
                });
            }
            return Content(isOk.ToString());

        }
    }
}
