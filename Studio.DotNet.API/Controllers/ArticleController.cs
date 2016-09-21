using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Studio.DotNet.API.Model;

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
        public IEnumerable<string> Get(Domain.TblArticle article)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var article = await _articleBll.GetAsync(id);
            return Json(article);
        }

        [ResponseCache(Duration = 60)]
        [HttpGet("~/Article/AddView")]
        public IActionResult AddView()
        {
            return View();
        }

        [HttpGet("~/Article/DetailView")]
        public IActionResult DetailView()
        {
            return View();
        }


        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]    // 防止跨域攻击
        public async Task<IActionResult> Post([FromBody]Model.ArticleViewModel article)
        {
            article.UserId = 1; // TODO default value is admin
            if (!ModelState.IsValid){return Json(new
            {
                Status="error",
                Msg = ModelState
                    .Values
                    .First(e => e.Errors.Count > 0)
                    .Errors.First().ErrorMessage
            }); }
            var result = await _articleBll.AddAsync(article,
                Regex.Split(article.Tags.Trim(), @"\s")
                    .Where(m => !string.IsNullOrWhiteSpace(m))
                    .Select(t => new Domain.TblTag { Value = t }), article.UserId);
            return Json(new AjaxJsonResult { Status = "ok", Data = article, Message = "提交成功"});
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
            var fileExt = Path.GetExtension(file.FileName);
            var ticks = DateTime.Now.Ticks;
            var saveHtmlPath = $@"{webrootPath}\article\html\{ticks}\{ticks}.html";
            var saveHtmlPath2 = $@"/article/html/{ticks}/{ticks}.html";
            var savePath = $@"{webrootPath}\article\word\{ticks}{fileExt}";
            Directory.CreateDirectory($@"{webrootPath}\article\word\");
            try
            {
                using (var fs = System.IO.File.Open(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(fs);
                    await fs.SaveAsync(FileStreamEx.FileType.Word, saveHtmlPath);
                }
            }
            catch (Exception)
            {
                System.IO.File.Delete(savePath);
                throw;
            }
            return Json(new { status = "ok", data = saveHtmlPath2, msg = "html文件已经转换成功" });
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
