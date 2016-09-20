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
    public class UserControllerTest
    {
        public UserControllerTest()
        {
        }

        [Fact]
        public void PostAsyncTest()
        {
            string reqeustString = @"
                POST http://localhost:6688/api/user HTTP/1.1
                Host: localhost:6688
                Content-Length: 42
                Content-Type: application/json; charset=utf-8

                {""email"":""test@test.com"",""password"":""123123""}";
            var response = new HttpClient().SendAsync(HttpRequestMessageEx.CreateFromRaw(reqeustString)).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var userid = Convert.ToInt32(Regex.Match(content, @"id.+?(?<userid>\d+)").Result("${userid}"));
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);
            Assert.True(Regex.IsMatch(content, "id", RegexOptions.IgnoreCase));
            Assert.True(userid > 0);
        }
    }
}
