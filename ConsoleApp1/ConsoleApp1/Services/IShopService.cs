﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shops.Models;

namespace Shops.Services
{
    public interface IShopService
    {
        Product AddProduct(string name, int amount, int price, Shop shop);
        Shop AddShop(string name, string address);
        Product FindProduct(string name, Shop shop);
        bool IsProductInShop(Product product, Shop shop);
        Shop FindCheapestProduct(string productName, int productAmount);
        int Buy(Dictionary<string, int> shopList, Buyer buyer, Shop shop);
    }
}
