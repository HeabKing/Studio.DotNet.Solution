using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Studio.DotNet.API.Model;
using Xunit;

namespace Studio.DotNet.API.Test
{
	/// <summary>
	/// 由于公共数据库访问逻辑约定实体字段名与数据库字段名一致, 所以创建单元测试保证这一约定的执行
	/// </summary>
    public class ViewModelTest
    {
		[Fact]
	    public void AllModelTest()
	    {
			var domaintypes = typeof(Domain.TblUser).Assembly.DefinedTypes;
		    var tblUser = domaintypes.Single(m => m.Name == nameof(Domain.TblUser));
			var apitypes = typeof(Model.RegisterViewModel).Assembly.DefinedTypes;
		    var registerVm = apitypes.Single(t => t.Name == nameof(Model.RegisterViewModel));
			    foreach (var p in registerVm.GetProperties())
			    {
				    if (p.CustomAttributes.Any(a => a.AttributeType == typeof(NoDbAttribute)))
				    {
						// 如果添加了NoDb, 那么Domain中肯定没此字段
					    Assert.False(tblUser.GetProperties().Any(m => m.Name == p.Name));
				    }
				    else
				    {
						// 如果没有添加NoDb, 那么Domain中肯定有此字段
					    Assert.True(tblUser.GetProperties().Any(m => m.Name == p.Name));
				    }
			    }
		}
    }
}
