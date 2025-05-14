using System;
using System.Collections.Generic;
using Shops.Models;
using Shops.Services;
using Shops.Payment.Interfaces;
using Shops.Payment.Processors;

class Program
{
    static void Main()
    {
        var shopService = new ShopService();
        var shop = shopService.AddShop("Digital Store", "Online");
        var buyer = new Buyer("Alice", 5000);

        shopService.AddProduct("Phone", 10, 1500, shop);
        shopService.AddProduct("Headphones", 20, 200, shop);

        var productsToBuy = new Dictionary<string, int>
        {
            { "Phone", 1 },
            { "Headphones", 2 }
        };

        int totalCost = shopService.Buy(productsToBuy, buyer, shop);
        Console.WriteLine($"Total cost: {totalCost}");
        Console.WriteLine($"Remaining balance: {buyer.Money}");

        
        IPaymentProcessor paymentProcessor = new CreditCardProcessor();
        IPaymentValidator? validator = paymentProcessor as IPaymentValidator;

        if (validator != null)
        {
            string cardNumber = "1234567812345678";
            if (!validator.ValidatePayment(cardNumber))
            {
                Console.WriteLine("Invalid credit card!");
                return;
            }
        }

        if (paymentProcessor.ProcessPayment(totalCost))
        {
            Console.WriteLine("Payment successful.");
        }
        else
        {
            Console.WriteLine("Payment failed.");
        }
    }
}
