using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product
{
    public class RequestInsertProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
