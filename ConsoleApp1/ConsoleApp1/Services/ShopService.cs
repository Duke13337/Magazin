using System;
using System.Collections.Generic;
using Shops.Models;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopService : IShopService
    {
        private List<Shop> _shops;

        public ShopService()
        {
            _shops = new List<Shop>();
        }

        public Product AddProduct(string name, int amount, int price, Shop shop)
        {
            var product = new Product(name, amount, price);
            shop.AddProductToShop(product);
            return product;
        }

        public Shop AddShop(string name, string address)
        {
            var shop = new Shop(name, address);
            _shops.Add(shop);
            return shop;
        }

        public Product FindProduct(string name, Shop shop)
        {
            foreach (Product product in shop.Products)
            {
                if (product.Name == name)
                    return product;
            }

            throw new ShopsException("No such product in this shop");
        }

        public bool IsProductInShop(Product product, Shop shop)
        {
            return shop.Products.Contains(product);
        }

        public Shop FindCheapestProduct(string productName, int productAmount)
        {
            Shop result = null;
            int minPrice = int.MaxValue;

            foreach (Shop shop in _shops)
            {
                foreach (Product product in shop.Products)
                {
                    if (product.Name == productName && product.Amount >= productAmount && product.Price < minPrice)
                    {
                        result = shop;
                        minPrice = product.Price;
                    }
                }
            }

            return result ?? throw new ShopsException("No such product in shops");
        }

        public int Buy(Dictionary<string, int> shopList, Buyer buyer, Shop shop)
        {
            int checkAmount = 0;

            foreach (var keyValue in shopList)
            {
                string productName = keyValue.Key;
                int amount = keyValue.Value;

                foreach (Product product in shop.Products)
                {
                    int cost = amount * product.Price;
                    if (product.Name == productName && product.Amount >= amount && buyer.Money >= cost)
                    {
                        checkAmount += cost;
                        buyer.Paying(cost);
                        product.RemoveAmount(amount);
                    }
                }
            }

            return checkAmount;
        }
    }
}
