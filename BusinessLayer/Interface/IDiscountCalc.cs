using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IDiscountCalc
    {
        decimal GetDiscountRate(Person person);
    }
}
