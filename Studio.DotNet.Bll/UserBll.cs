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
        public async Task<bool> AddAsync(Domain.TbUserDto model)
        {
            model.PwdHash = Hesinx.Utility.SecurityHelper.Md5(model.PwdHash);  // MD5加密
            var num = await _dal.InsertAsync(model);
            return num == 1;
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Domain.TbUserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TbUserDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
