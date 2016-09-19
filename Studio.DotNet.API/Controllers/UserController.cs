using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Studio.DotNet.API.Controllers
{
	/// <summary>
	/// 用户相关API
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
    [Route("api/[controller]")]
    public class UserController : Controller
	{
		/// <summary>
		/// 用户逻辑访问层
		/// </summary>
		private readonly IBll.IUserBll _userBll;

		/// <summary>
		/// 获取服务
		/// </summary>
		/// <param name="bll"></param>
		/// <remarks>Sinx 2016-08-31</remarks>
		public UserController(IBll.IUserBll bll)
		{
			_userBll = bll;
		}

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
		/// 获取单个用户信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <remarks>Sinx 2016-08-31</remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
			var user = await _userBll.GetAsync(id);
			return Json(user);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Domain.TblUser user)
        {
            if (!ModelState.IsValid) return BadRequest();
            user.Id = await _userBll.AddAsync(user);
            var claims = new List<Claim>
            {
                new Claim("DotNetStudio.Account", ""),
                new Claim($"DotNetStudio.Account.{nameof(user.Email)}", user.Email),
                new Claim($"DotNetStudio.Account.{nameof(user.Id)}", user.Id.ToString())
            };
            await HttpContext.Authentication.SignInAsync("DotNetStudio.Login",
                new ClaimsPrincipal(new ClaimsIdentity(claims)));
            HttpContext.Response.StatusCode = 201;
            return Json(new { Status = "ok", Data = new { user.Id }, Message = "created" });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
