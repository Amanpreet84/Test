using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IDeductionCalc
    {        
        decimal GetDeductionPerPaycheck(List<Person> persons, int numberOfPaychecksPerYear);
        
        decimal GetDeductionPerYear(List<Person> persons);
        
        decimal GetDeductionWithDiscountType(Person person);
    }
}
