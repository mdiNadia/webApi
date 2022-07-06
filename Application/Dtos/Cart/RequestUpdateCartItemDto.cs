using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Cart
{
    public class RequestUpdateCartItemDto
    {
        public int ItemId { get; set; }
        public int ItemQty { get; set; }

    }
}
