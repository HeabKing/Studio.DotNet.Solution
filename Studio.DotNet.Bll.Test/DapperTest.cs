using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Dapper;

namespace Studio.DotNet.Bll.Test
{
    public class DapperTest
    {
	    private readonly System.Data.IDbConnection _db;
		public DapperTest()
		{
			IServiceCollection services = new ServiceCollection();
			CompositionRoot.Startup.ConfigureServices(services);
			var s = services.BuildServiceProvider();
			_db = s.GetService<System.Data.IDbConnection>();
		}

		[Fact]
	    public void MutileResultTest()
		{

			var rows = _db.Query("select 1 A, 2 B union all select 3, 4");
		}
    }
}
