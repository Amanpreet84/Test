﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DiscountCalc : IDiscountCalc
    {
        public decimal GetDiscountRate(Person person)
        {
            if (person?.Name?.ToLower().StartsWith("a") ?? false)
                return Constants.TEN_PERCENT_DISCOUNT_RATE; // 10 percent discount rate
            else
                return Constants.ZERO_PERCENT_DISCOUNT_RATE; // no discount
        }
    }
}
