using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCalculator.Enums.Bank
{
    public enum RequestStatus :int
    {
        Waiting= 0,
        Approved = 1,
        Declined=2,
    }
}
