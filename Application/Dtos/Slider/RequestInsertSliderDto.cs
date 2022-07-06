using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Slider
{
    public class RequestInsertSliderDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }

    }
}
