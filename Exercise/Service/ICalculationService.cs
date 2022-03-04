using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public interface ICalculationService
    {
        CalculationResults CalculateDeductions(Employee employee);
    }
}
