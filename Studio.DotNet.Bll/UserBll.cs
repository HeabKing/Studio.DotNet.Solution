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

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(Domain.TblUserDto model)
        {
           return null;
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Domain.TblUserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TblUserDto> GetAsync(int id)
        {
	        return _dal.GetAsync(id);
        }
    }
}
