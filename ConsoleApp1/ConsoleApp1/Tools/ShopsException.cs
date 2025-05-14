using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shops.Tools
{
    public class ShopsException : Exception
    {
        public ShopsException(string message)
            : base(message)
        {
        }
    }
}
