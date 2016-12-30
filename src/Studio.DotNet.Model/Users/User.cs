using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinx.Infrastructure.DomainBase;

namespace Studio.DotNet.Model.Users
{
	public class User : EntityBase
	{
		public User(int id) : base(key: id)
		{
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public bool IsEmailChecked { get; set; }
		public DateTime CreateTime { get; set; }
		public bool IsDelete { get; set; }
	}
}
