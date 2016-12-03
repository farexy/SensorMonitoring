using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTester.Models
{
    class RequestViewModel
    {
        public long EllapsedMilliseconds { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
    }
}
