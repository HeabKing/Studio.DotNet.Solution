using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.IBll
{
    public interface IUserBll : IBaseBll<Domain.TblUser>
    {
        Task<Domain.TblUser> GetOrDefaultAsync(Domain.TblUser user);
    }
}
