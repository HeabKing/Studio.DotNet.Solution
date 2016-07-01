using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Studio.DotNet.Dal
{
    public class TbUserDal : IDal.ITbUserDal, IDal.IBaseDal<Domain.TbUserDto>
    {
        private readonly IDbConnection _db;
        public TbUserDal(IDbConnection db)
        {
            _db = db;
        }

        public Task<int> InsertAsync(Domain.TbUserDto model)
        {
            return _db.ExecuteAsync(@"
                INSERT INTO [dbo].[TbUser]
			                ([UserName]
                           ,[PwdHash])
                     VALUES
                           (@UserName
                           ,@PwdHash)", model);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Domain.TbUserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TbUserDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
