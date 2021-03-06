﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Studio.DotNet.Bll.Test
{
	/// <summary>
	/// 用户逻辑层的单元测试
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
	public class UserBllTest
	{
		/// <summary>
		/// 代表用户访问层
		/// </summary>
		private readonly IBll.IUserBll _userBll;
		/// <summary>
		/// 从组合根中获取服务
		/// </summary>
		/// <remarks>Sinx 2016-08-31</remarks>
		public UserBllTest()
		{
			IServiceCollection services = new ServiceCollection();
			CompositionRoot.Startup.ConfigureServices(services);
			_userBll = services.BuildServiceProvider().GetService<IBll.IUserBll>();
		}


		/// <summary>
		/// 获取单个用户测试
		/// </summary>
		/// <remarks>Sinx 2016-08-31</remarks>
		[Fact]
		public void GetAsyncTest()
		{
			const int id = 1;
			var user = _userBll.GetAsync(new Domain.TblUser { Id = id }).Result.FirstOrDefault();
			Assert.True(user?.Id == id);
			Assert.NotNull(user?.Name);
		}

		/// <summary>
		/// 添加用户测试
		/// </summary>
		[Fact]
		public void AddAsyncTest()
		{
			var userid = _userBll.AddAsync(new Domain.TblUser
			{
				Email = "Test@Test@qq.com",
				Password = "Test"
			}).Result;
			Assert.True(userid > 0);
		}
	}
}
