using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Studio.DotNet.API.Controllers
{
	[Route("api/[controller]")]
	public class ArticleController : Controller
	{
		private readonly IBll.IAritlceBll _articleBll;
		private readonly IHostingEnvironment _env;

		public ArticleController(IBll.IAritlceBll bll, IHostingEnvironment hostingEnvironment)
		{
			_articleBll = bll;
			_env = hostingEnvironment;
		}

		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] {"value1", "value2"};
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var article = await _articleBll.GetAsync(id);
			return Json(article);
		}

		/// <summary>
		/// 添加文章
		/// </summary>
		/// <param name="article"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Post(Model.ArticleViewModel article)
		{
			var result = await _articleBll.AddAsync(article.Article, article.Tags, article.UserId);
			return Json(article);
		}

		/// <summary>
		/// 添加ContentUrl, 将传入的word文件转换成html
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("ContentUrl")]
		public async Task<IActionResult> PostContentUrl()
		{
			// 转换 word 文件为html, 生成路径
			var webrootPath = _env.WebRootPath;
			var file = Request.Form.Files["file"];
			var fileExt = System.IO.Path.GetExtension(file.FileName);
			var ticks = DateTime.Now.Ticks;
			var savePath = $@"{webrootPath}\article\word\{ticks}{fileExt}";
			var saveHtmlPath = $@"{webrootPath}\article\html\{ticks}\{ticks}.html";
			var saveHtmlPath2 = $@"/article/html/{ticks}/{ticks}.html";
			using (var stream = System.IO.File.OpenWrite(savePath))
			{
				await file.CopyToAsync(stream);
			}
			var des = $@"{savePath};{saveHtmlPath}";
			var p = Process.Start(@"C:\Users\HeabK\Sinx\aspose", $"\"{des}\"");
			// 等待退出, 最多等一分钟
			p.WaitForExit(Convert.ToInt32(TimeSpan.FromMinutes(1).TotalMilliseconds));
			var contentUrl = string.Empty;
			// 如果CMD成功执行完成, 返回的是0, 如果出现异常等, 返回的是非零
			if (p.ExitCode == 0)
			{
				contentUrl = saveHtmlPath2;
			}
			return Json(new {status = "ok", data = contentUrl, msg = "html文件已经转换成功"});
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
