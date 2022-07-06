using Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Slider
{
   public class GetSlidersByFilterDto : ResponseFilterDataDto
    {
        public List<GetSlidersDto> Result { get; set; }

    }
}
