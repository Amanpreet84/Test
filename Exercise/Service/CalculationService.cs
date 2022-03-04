using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise
{
    public class CalculationService : ICalculationService
    {
        private readonly IDeductionCalc _deductionCalculator;

        public CalculationService(IDeductionCalc deductionCalculator)
        {
            _deductionCalculator = deductionCalculator;
        }
        public CalculationResults CalculateDeductions(Employee employee)
        {
            List<Person> persons = ConvertEmployeeToPersonList(employee);            
           
            decimal employeeDedudctionPerPayCheck = _deductionCalculator.GetDeductionPerPaycheck(persons.Where(p => p.Type == RelationType.Employee).ToList(), employee.NumberOfPaychecksPerYear);
            decimal dependentsDeductionPerPayCheck = _deductionCalculator.GetDeductionPerPaycheck(persons.Where(p => p.Type != RelationType.Employee).ToList(), employee.NumberOfPaychecksPerYear);
            decimal totalDeductionPerPayCheck = _deductionCalculator.GetDeductionPerPaycheck(persons, employee.NumberOfPaychecksPerYear);
            decimal employeeDeductionPerYear = _deductionCalculator.GetDeductionPerYear(persons.Where(p => p.Type == RelationType.Employee).ToList());
            decimal dependentDeductionPerYear = _deductionCalculator.GetDeductionPerYear(persons.Where(p => p.Type != RelationType.Employee).ToList());
            decimal totalDeductionPerYear = _deductionCalculator.GetDeductionPerYear(persons);
            decimal employeePaycheckAfterDeductions = (employee.YearlySalary / (decimal)employee.NumberOfPaychecksPerYear) - totalDeductionPerPayCheck;
            decimal employeeYearlyPayAfterDeductions = employee.YearlySalary - totalDeductionPerYear;

            return new CalculationResults()
            {
                EmployeeDeductionPerPayCheck = employeeDedudctionPerPayCheck,
                DependentsDeductionPerPayCheck = dependentsDeductionPerPayCheck,
                TotalDeductionPerPayCheck = totalDeductionPerPayCheck,
                EmployeeDeductionPerYear = employeeDeductionPerYear,
                DependentsDeductionPerYear = dependentDeductionPerYear,
                TotalDeductionPerYear = totalDeductionPerYear,
                EmployeePaycheckAfterDeductions = employeePaycheckAfterDeductions,
                EmployeeYearlyPayAfterDeductions = employeeYearlyPayAfterDeductions
            };
        }

        public static List<Person> ConvertEmployeeToPersonList(Employee employee)
        {
            var returnList = new List<Person>();

            returnList.Add(new Person() { Name = employee.Name, Type = RelationType.Employee });

            foreach (var dependent in employee.Dependents)
            {
                returnList.Add(new Person() { Name = dependent.Name, Type = ConvertDependentTypeToPersonType(dependent.Type) });
            }

            return returnList;
        }

        public static RelationType ConvertDependentTypeToPersonType(DependentType type)
        {
            switch (type)
            {
                case DependentType.Child:
                    return RelationType.Child;
                case DependentType.Spouse:
                    return RelationType.Spouse;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}