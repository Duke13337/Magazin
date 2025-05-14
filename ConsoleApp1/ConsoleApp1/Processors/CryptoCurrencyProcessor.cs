using System;
using Shops.Payment.Interfaces;

namespace Shops.Payment.Processors
{
    public class CryptoCurrencyProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing crypto payment: {amount} BTC");
            return true;
        }

        public void RefundPayment(decimal amount)
        {
            Console.WriteLine($"Refunding crypto payment: {amount} BTC");
        }
    }
}
