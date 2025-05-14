using System;
using Shops.Payment.Interfaces;

namespace Shops.Payment.Processors
{
    public class CreditCardProcessor : IPaymentProcessor, IPaymentValidator
    {
        public bool ValidatePayment(string cardNumber)
        {
            Console.WriteLine($"Validating credit card: {cardNumber}");
            return !string.IsNullOrWhiteSpace(cardNumber) && cardNumber.Length == 16;
        }

        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment: {amount:C}");
            return true;
        }

        public void RefundPayment(decimal amount)
        {
            Console.WriteLine($"Refunding credit card payment: {amount:C}");
        }
    }
}
