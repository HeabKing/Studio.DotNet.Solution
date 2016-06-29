using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Domain
{
    public class TbUserDto
    {
        public string Id { get; set; }
        public int UserNum { get; set; }
        public string UserName { get; set; }
        public string PwdHash { get; set; }
    }
}
