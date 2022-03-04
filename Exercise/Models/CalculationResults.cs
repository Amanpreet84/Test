﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise
{
    public class CalculationResults
    {
        public decimal TotalDeductionPerPayCheck { get; set; }        
        public decimal DependentsDeductionPerPayCheck { get; set; }       
        public decimal EmployeeDeductionPerPayCheck { get; set; }        
        public decimal EmployeeDeductionPerYear { get; set; }       
        public decimal DependentsDeductionPerYear { get; set; }        
        public decimal TotalDeductionPerYear { get; set; }        
        public decimal EmployeePaycheckAfterDeductions { get; set; }        
        public decimal EmployeeYearlyPayAfterDeductions { get; set; }
    }
}