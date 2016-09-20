using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Studio.DotNet.Dal
{
    public class TblTagDal : IDal.ITblTagDal
    {
	    private readonly System.Data.IDbConnection _db;
		public TblTagDal(System.Data.IDbConnection db)
		{
			_db = db;
		}
	    public Task<int> InsertAsync(Domain.TblTag model)
	    {
		    return _db.ExecuteAsync(@"
				INSERT INTO [dbo].[TblTag]
						   ([Value])
					 VALUES
						   (@Value)", model);
	    }

	    public Task<int> DeleteAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<int> UpdateAsync(Domain.TblTag model)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<Domain.TblTag> GetOrDefaultAsync(int id)
	    {
		    return _db.QueryFirstOrDefaultAsync<Domain.TblTag>("SELECT * FROM dbo.TblTag WHERE Id = @id;", new { id });
	    }

	    public async Task<Domain.TblTag> GetAsync(int id)
	    {
		    var tag = await GetOrDefaultAsync(id).ConfigureAwait(false);
			if (tag == null)
			{
				throw new Exception($"指定id下{id}无内容");
			}
			return tag;
	    }

        public Task<Domain.TblTag> GetAsync(Domain.TblTag model)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TblTag> GetOrDefaultAsync(Domain.TblTag model)
        {
            return _db.QueryFirstOrDefaultAsync<Domain.TblTag>("SELECT * FROM dbo.TblTag WHERE Value = @Value;", model);
        }
    }
}
