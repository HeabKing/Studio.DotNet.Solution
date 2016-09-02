using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Studio.DotNet.Domain;

// ReSharper disable ClassNeverInstantiated.Global
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

        public Task<int> InsertAsync(Domain.TblUser model)
        {
			return null;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Domain.TblUser model)
        {
            throw new NotImplementedException();
        }
			
        public Task<Domain.TblUser> GetOrDefaultAsync(int id)
        {
	        return _db.QueryFirstAsync<Domain.TblUser>(@"
				SELECT *
				FROM dbo.TblUser
				WHERE Id = @id
				", new {id});
        }

	    public Task<TblUser> GetAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblUser> GetAsync(string field)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblUser> GetOrDefaultAsync(string field)
	    {
		    throw new NotImplementedException();
	    }
    }
}
