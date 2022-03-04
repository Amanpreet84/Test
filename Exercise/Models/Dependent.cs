using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise
{   
    public enum DependentType
    {
        Spouse,
        Child
    }

    public class Dependent : Persons
    {
        public DependentType Type { get; set; }
    }
}