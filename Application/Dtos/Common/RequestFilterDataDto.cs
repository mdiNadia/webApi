using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Common
{
    public class RequestFilterDataDto
    {
        public int Pageno { get; set; }
        public string Search { get; set; }
        public string Key { get; set; }
        public string SortId { get; set; }
        public int Take { get; set; }
    }
}
