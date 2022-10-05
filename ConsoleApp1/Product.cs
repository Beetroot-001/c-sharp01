﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product
    {
        private string _description;
        private string Description { 
            get => _description;
            set => _description = value;
        }

        private float _price;
        private float Price
        {
            get => _price;
            set => _price = value;
        }

        private int _quantity;
        private int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
    }
}
