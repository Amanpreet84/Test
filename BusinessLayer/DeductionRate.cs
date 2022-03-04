using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DeductionRate : IDeductionRate
    {
        public decimal Get(RelationType personType)
        {
            switch (personType)
            {
                case RelationType.Employee:
                    return Constants.EMPLOYEE_DEDUCTION_PER_YEAR;
                case RelationType.Spouse:
                case RelationType.Child:
                    return Constants.DEPENDENT_DEDUCTION_PER_YEAR;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
