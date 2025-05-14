using System;
using Shops.Payment.Interfaces;

namespace ConsoleApp1.Processors
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment: {amount:C}");
            return true;
        }

        public void RefundPayment(decimal amount)
        {
            Console.WriteLine($"Refunding PayPal payment: {amount:C}");
        }
    }
}
