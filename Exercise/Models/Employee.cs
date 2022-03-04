using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise
{
    public class Employee : Persons
    {        
        public int YearlySalary { get; set; }        
        public int NumberOfPaychecksPerYear { get; set; }
        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}