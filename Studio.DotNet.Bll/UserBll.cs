using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Bll
{
    public class UserBll : IBll.IUserBll
    {
        private readonly IDal.ITbUserDal _dal;
        public UserBll(IDal.ITbUserDal dal)
        {
            _dal = dal;
        }
        public async Task<Domain.TblUser> GetOrDefaultAsync(Domain.TblUser user)
        {
            var getuser = await _dal.GetOrDefaultAsync(user) ?? new Domain.TblUser();
            return getuser.Password != user.Password ? null : getuser;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public Task<int> AddAsync(Domain.TblUser user)
        {
            return _dal.InsertAsync(user);
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Domain.TblUser model)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TblUser> GetAsync(int id)
        {
            return _dal.GetOrDefaultAsync(id);
        }


    }
}
