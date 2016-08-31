using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Studio.DotNet.Dal
{
	/// <summary>
	/// 用户表相关操作
	/// </summary>
    public class TblUserDal : IDal.ITbUserDal
    {
        private readonly IDbConnection _db;
        public TblUserDal(IDbConnection db)
        {
            _db = db;
        }

        public Task<int> InsertAsync(Domain.TblUserDto model)
        {
			return null;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Domain.TblUserDto model)
        {
            throw new NotImplementedException();
        }
			
        public Task<Domain.TblUserDto> GetAsync(int id)
        {
	        return _db.QueryFirstAsync<Domain.TblUserDto>(@"
				SELECT *
				FROM dbo.TblUser
				WHERE Id = 1
				", id);
        }
    }
}
