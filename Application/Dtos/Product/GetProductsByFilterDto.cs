using Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product
{
   public class GetProductsByFilterDto:ResponseFilterDataDto
    {
        public List<GetProductsDto> Result { get; set; }

    }
}
