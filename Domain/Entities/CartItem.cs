﻿using Domain.Enums;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public OrderStatus CartStatus { get; set; }
    }
}
