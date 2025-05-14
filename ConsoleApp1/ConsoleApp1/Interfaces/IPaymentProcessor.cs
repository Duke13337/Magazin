using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Payment.Interfaces
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);   
        void RefundPayment(decimal amount);    
    }
}
