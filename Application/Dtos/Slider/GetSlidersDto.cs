using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Slider
{
   public class GetSlidersDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string CreateDate { get; set; }
    }
}
