﻿using eMusicStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMusicStore.Web.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}