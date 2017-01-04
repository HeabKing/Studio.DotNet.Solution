using System;
using System.Data;

namespace Studio.DotNet.Infrastructure.Repositories.Users
{
	/// <summary>
	/// 资源库
	/// </summary>
    public class UserRepository : IUserRepository
    {
	    private readonly IDbConnection _db;

	    public UserRepository(IDbConnection db)
	    {
		    _db = db;
	    }

	    public Model.Users.User FindBy(object key)
	    {
		    var id = (int)key;
		    return _db.GetAsync<Model.Users.User>(id).Result;
	    }

	    public void Add(Model.Users.User entity)
	    {
		    _db.InsertAsync(entity);
	    }

	    public Model.Users.User this[object key]
	    {
		    get { return this.FindBy(key); }
		    set { _db.InsertAsync(value); }
	    }

	    public void Remove(Model.Users.User entity)
	    {
			entity.IsDelete = true;
		    _db.UpdateAsync(entity);
	    }
    }
}
