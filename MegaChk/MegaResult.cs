using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChk
{
    internal class MegaResult
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public long UsedQuotaMB { get; set; }
        public long TotalQuotaMB { get; set; }
    }
}
