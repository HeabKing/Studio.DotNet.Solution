using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Bll
{
	public class UserBll : BaseBll<Domain.TblUser>, IBll.IUserBll
	{
		private readonly IDal.ITblUserDal _dal;
		public UserBll(IDal.ITblUserDal dal) : base(dal)
		{
			_dal = dal;
		}
		public async Task<Domain.TblUser> GetOrDefaultAsync(Domain.TblUser user)
		{
			var getuser = (await _dal.GetAsync(user)).FirstOrDefault() ?? new Domain.TblUser();
			return getuser.Password != user.Password ? null : getuser;
		}
	}
}
