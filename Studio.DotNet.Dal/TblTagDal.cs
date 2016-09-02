using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studio.DotNet.Domain;
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
	    public Task<int> InsertAsync(TblTag model)
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

	    public Task<int> UpdateAsync(TblTag model)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblTag> GetOrDefaultAsync(int id)
	    {
		    return _db.QueryFirstOrDefaultAsync<Domain.TblTag>("SELECT * FROM dbo.TblTag WHERE Id = @id;", new { id });
	    }

	    public async Task<TblTag> GetAsync(int id)
	    {
		    var tag = await GetOrDefaultAsync(id).ConfigureAwait(false);
			if (tag == null)
			{
				throw new Exception($"指定id下{id}无内容");
			}
			return tag;
	    }

	    public async Task<TblTag> GetAsync(string value)
		{
			var tag = await GetOrDefaultAsync(value).ConfigureAwait(false);
			if (tag == null)
			{
				throw new Exception($"指定{nameof(value)}下{value}无内容");
			}
			return tag;
		}

	    public Task<TblTag> GetOrDefaultAsync(string value)
	    {
			return _db.QueryFirstOrDefaultAsync<Domain.TblTag>("SELECT * FROM dbo.TblTag WHERE Value = @value;", new { value });
		}
    }
}
