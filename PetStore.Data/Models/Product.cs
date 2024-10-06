﻿using PetStore.Data.Models;

namespace PetStore.Data;

public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Order ProductOrder { get; set; }
        public int OrderId { get; set; }

    }