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
            string requestString = @"
                POST http://localhost:6688/api/user HTTP/1.1
                Host: localhost:6688
                Content-Length: 42
                Content-Type: application/json; charset=utf-8

                {""email"":""test@test.com"",""password"":""123123""}";
            using (var client = new HttpClient())
            {
                var response = client.SendAsync(HttpRequestMessageEx.CreateFromRaw(requestString)).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var userid = Convert.ToInt32(Regex.Match(content, @"id.+?(?<userid>\d+)").Result("${userid}"));
                Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);  // created user
                Assert.True(Regex.IsMatch(content, "id", RegexOptions.IgnoreCase));     // returned userid
                Assert.True(userid > 0);    // returned correct userid
                Assert.True(response.Headers.Any(h => h.Key == "Set-Cookie"));          // add cookie to front client    

                // if email format is invalid return 401 bad request
                response = client.SendAsync(HttpRequestMessageEx.CreateFromRaw(requestString.Replace("@", ""))).Result;
                Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
