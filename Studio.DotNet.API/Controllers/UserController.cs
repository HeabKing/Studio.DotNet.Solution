using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Post([FromBody]string value)
        {
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
