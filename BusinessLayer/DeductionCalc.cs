using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLayer
{
    public class DeductionCalc : IDeductionCalc
    {
        private readonly IDeductionRate _deductionRate;
        private readonly IDiscountCalc _discountCalc;

        public DeductionCalc(IDeductionRate deductionRate, IDiscountCalc discountCalc)
        {
            _deductionRate = deductionRate;
            _discountCalc = discountCalc;
        }
        public decimal GetDeductionPerPaycheck(List<Person> persons, int numberOfPaychecksPerYear)
        {
            return GetDeductionPerYear(persons) / numberOfPaychecksPerYear;
        }

        public decimal GetDeductionPerYear(List<Person> persons)
        {
            return persons.Sum(person => GetDeductionWithDiscountType(person));
        }

        public decimal GetDeductionWithDiscountType(Person person)
        {
            return _deductionRate.Get(person.Type) * (1 - (decimal)_discountCalc.GetDiscountRate(person));
        }       
    }
}
