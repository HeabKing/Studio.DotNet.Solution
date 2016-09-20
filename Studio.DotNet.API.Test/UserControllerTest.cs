using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sinx.Utility.Extension;
using Xunit;

namespace Studio.DotNet.API.Test
{
    public class UserControllerTest : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        public UserControllerTest()
        {
        }

        /// <summary>
        /// 注册测试
        /// </summary>
        [Fact]
        public void PostAsyncTest()
        {
            const string requestString = @"
                POST http://localhost:6688/api/user HTTP/1.1
                Host: localhost:6688
                Content-Length: 42
                Content-Type: application/json; charset=utf-8

                {""email"":""test@test.com"",""password"":""123123""}";
                var response = _client.SendAsync(HttpRequestMessageEx.CreateFromRaw(requestString)).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var userid = Convert.ToInt32(Regex.Match(content, @"id.+?(?<userid>\d+)").Result("${userid}"));
                Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);  // created user
                Assert.True(Regex.IsMatch(content, "id", RegexOptions.IgnoreCase));     // returned userid
                Assert.True(userid > 0);    // returned correct userid
                Assert.True(response.Headers.Any(h => h.Key == "Set-Cookie"));          // add cookie to front client    

                // if email format is invalid return 401 bad request
                response = _client.SendAsync(HttpRequestMessageEx.CreateFromRaw(requestString.Replace("@", ""))).Result;
                Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// 用户登录 - Cookie设置 测试
        /// </summary>
        [Fact]
        public void GetCookieAsync()
        {
            const string requestString = @"
                POST http://localhost:6688/api/user/cookie HTTP/1.1
                Host: localhost:6688
                Content-Length: 42
                Content-Type: application/json; charset=utf-8

                {""email"":""test@test.com"",""password"":""123123""}";

            var response = _client.SendAsync(HttpRequestMessageEx.CreateFromRaw(requestString)).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var userid = Convert.ToInt32(Regex.Match(content, @"id.+?(?<userid>\d+)").Result("${userid}"));
            Assert.True(Regex.IsMatch(content, "ok", RegexOptions.IgnoreCase)); // process successfully
            Assert.True(response.Headers.Any(h => h.Key == "Set-Cookie"));      // get cookie successfully
            Assert.True(userid > 0);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
