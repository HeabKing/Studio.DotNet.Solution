using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.API.Model
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = ("请输入邮箱地址"))]
		//[Display] TODO What is this
		[EmailAddress(ErrorMessage = "请输入合法的邮箱地址")]
		public string Email { get; set; }
		[Required(ErrorMessage = "请输入密码")]
		public string Password { get; set; }
		[NoDb]
		[Compare("Password", ErrorMessage = "两次输入密码不一致")]
		public string CheckPassword { get; set; }
	}
}
