// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Studio.DotNet.Domain
{
	/// <summary>
	/// 用户领域模型
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
	public class TblUser
    {
        public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
