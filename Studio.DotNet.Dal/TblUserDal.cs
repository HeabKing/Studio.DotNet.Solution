using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

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

        public Task<Domain.TblUser> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TblUser> GetOrDefaultAsync(int id)
        {
            return _db.QueryFirstAsync<Domain.TblUser>(@"
				SELECT *
				FROM dbo.TblUser
				WHERE Id = @id
				", new { id });
        }


        public Task<Domain.TblUser> GetAsync(Domain.TblUser model)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TblUser> GetOrDefaultAsync(Domain.TblUser user)
        {
            if (user.Id > 0) { return GetAsync(user.Id); }
            return _db.QueryFirstOrDefaultAsync<Domain.TblUser>(@"
                SELECT *
                FROM dbo.TblUser
                WHERE Email = @Email", user);
        }

        public Task<int> InsertAsync(Domain.TblUser user)
        {
            return _db.QueryFirstAsync<int>(@"
                INSERT INTO TblUser(Email, [Password])
                    VALUES(@Email, @Password);
                SELECT @@IDENTITY", user);
        }

        public Task<int> UpdateAsync(Domain.TblUser model)
        {
            throw new NotImplementedException();
        }



        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
