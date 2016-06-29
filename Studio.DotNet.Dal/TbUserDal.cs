using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Studio.DotNet.Domain;

namespace Studio.DotNet.Dal
{
    public class BaseDal : IDal.IBaseDal<Domain.TbUserDto>
    {
        private readonly IDbConnection _db;
        public BaseDal(IDbConnection db)
        {
            _db = db;
        }

        public Task<int> InsertAsync(TbUserDto model)
        {
            return _db.ExecuteAsync(@"
                INSERT INTO [dbo].[TbUser]
			                ([UserName]
                           ,[PwdHash])
                     VALUES
                           (@UserName
                           ,@PwdHash", model);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TbUserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<TbUserDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
