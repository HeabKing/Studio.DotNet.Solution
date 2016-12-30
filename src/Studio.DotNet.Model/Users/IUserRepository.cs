using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinx.Infrastructure.RepositoryFramework;

namespace Studio.DotNet.Model.Users
{
	/// <summary>
	/// 就像是 IUserDal : IBaseDal
	/// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }
}
