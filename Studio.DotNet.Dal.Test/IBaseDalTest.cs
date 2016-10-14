using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Studio.DotNet.Dal.Test
{
	public class IBaseDalTest
	{
		private readonly IDbConnection _db;
		public IBaseDalTest()
		{
			IServiceCollection services = new ServiceCollection();
			CompositionRoot.Startup.ConfigureServices(services);
			_db = services.BuildServiceProvider().GetService<IDbConnection>();
		}

		#region 2016-10-10 测试Get

		[Fact]
		public void GetAsyncTest()
		{
			var dal = new Dal.BaseDal<Domain.TblArticle>(_db, "dbo.TblArticle");
			var result = dal.GetAsync(new Domain.TblArticle { Id = 10000}).Result;
			Assert.True(result.Count() == 1);
		}

		#endregion

		#region 2016-10-09 准备
		[Fact]
		public void EqualsTest()
		{
			string a1 = "123";
			string a2 = "123";
			//Assert.False(a1 == a2);	// string中的==被重写为比较值
			Assert.True(a1.Equals(a2));

			object o1 = new object();
			object o2 = new object();
			Assert.False(o1 == o2);
			//Assert.True(o1.Equals(o2));	// 没有值的原因? 还是因为object中没有重写Equals

			var article1 = new Domain.TblArticle();
			var article2 = new Domain.TblArticle();
			Assert.False(article1 == article2);
			//Assert.True(article1.Equals(article2));

			var article3 = new Domain.TblArticle { Id = 1 };
			var article4 = new Domain.TblArticle { Id = 1 };
			Assert.False(article1 == article2);
			//Assert.True(article1.Equals(article2));	// C#类型都是int, string等有一个值的系统类型, 而自定义类中有多个值, 所以此时Equals是未定义的默认比较方式为false, 除非自己重写

			Int32 i1 = 1;
			Int32 i2 = 2 - 1;
			//Assert.False(i1 == i2);	// int32 中的 == 也被重写为比较值
			Assert.True(i1.Equals(i2));

			Int32 i3 = new Int32();
			i3 = 1;
			Int32 i4 = new Int32();
			i4 = 1;
			Assert.True(i3 == i4);
			Assert.True(i3.Equals(i4));
		}

		[Fact]
		public void JudgeObjectEqualsTest()
		{
			object o1 = new DateTime();
			object o2 = new DateTime();
			Assert.False(o1 == o2);
			Assert.True(o1.Equals(o2));

			object o3 = new int();
			object o4 = new Int32();
			Assert.False(o3 == o4);
			Assert.True(o3.Equals(o4));

			object o5 = "123";
			object o6 = "123";
			Assert.True(o5 == o6);  // 特例牛逼
			Assert.True((string)o5 == "123");   // (string) for warning when complie
			Assert.True(o5.Equals(o6));

			object o7 = new bool();
			object o8 = new bool();
			Assert.False(o7 == o8);
			Assert.True(o7.Equals(o8));
		}

		[Fact]
		public void GetOrDefaultAsyncTest()
		{
			// 验证反射获取类是否赋值
			var article = new Domain.TblArticle
			{
				ContentUrl = "12"
			};
			var type = article.GetType();
			TypeInfo typeInfo = type.GetTypeInfo();

			typeInfo.GetProperties().ToList().ForEach(p =>
			{
				//   var obj = Activator.CreateInstance(typeInfo);
				//   p.SetValue(obj, null, null);    // valueType -> 0, referenceType -> null
				//if (p.Name == "ContentUrl")
				//{
				//	Assert.True(p.GetValue(obj) != p.GetValue(article));
				//}
				//else
				//{
				//	Assert.True(0 == 0);
				//	var a1 = p.GetValue(obj);
				//	var a2 = p.GetValue(article);
				//	//Assert.True(p.GetValue(obj) == p.GetValue(article));
				//	Assert.True(a1 == a2);
				//}

				if (p.Name == "ContentUrl")
				{
					Assert.True(p.GetValue(article) != null);
				}
				else if (!p.PropertyType.IsValueType)
				{
					Assert.True(p.GetValue(article) == null);
				}
				else
				{
					if (Regex.IsMatch(p.PropertyType.Name, "Int16|Int32|Int64|DateTime|Boolean"))
					{
						Assert.True(p.GetValue(article).Equals(Activator.CreateInstance(p.PropertyType)));  // string, int, Date
					}
					else
					{
						throw new Exception("请先确认此类型是否重写了合适的Equals方法, 然后添加为合法");
					}
				}
			});
		}

		[Fact]
		public void GetIsValueTypeTest()
		{
			var article = new Domain.TblArticle { Id = 1};
			var isValueType1 = article.GetType().GetTypeInfo().GetProperty("Id").PropertyType.IsValueType;
			Assert.True(isValueType1);
			var isValueType2 = article.GetType().GetTypeInfo().DeclaredProperties.First(m => m.Name == "Id").PropertyType.GetTypeInfo().IsValueType;
			Assert.True(isValueType2);	// Property Type is ValueType
			// ReSharper disable once PossibleMistakenCallToGetType.2
			var isValueType3 = article.GetType().GetTypeInfo().DeclaredProperties.First(m => m.Name == "Id").PropertyType.GetType().GetTypeInfo().IsValueType;
			Assert.False(isValueType3);	// System.Type is ValueType
		}

		#endregion
	}
}
