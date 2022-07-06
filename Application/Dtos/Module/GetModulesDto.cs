using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Module
{
   public class GetModulesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Controller { get; set; }
        public int? ParentId { get; set; }
    }
}
