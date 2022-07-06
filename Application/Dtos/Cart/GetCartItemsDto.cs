﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Cart
{
    public class GetCartItemsDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }

        public decimal SumPrice { get; set; }
    }
}
