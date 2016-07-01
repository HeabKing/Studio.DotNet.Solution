using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.WebUI.Model
{
    /// <summary>
    /// 用户注册视图模型
    /// </summary>
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string  Pwd { get; set; }
        public string ConfirmPwd { get; set; }
        public string VerificationCode { get; set; }
    }
}
