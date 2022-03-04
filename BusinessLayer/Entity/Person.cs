using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public enum RelationType
    {
        Employee,
        Spouse,
        Child
    }

    public class Person
    {
        public string Name { get; set; }
        public RelationType Type { get; set; }
    }
}
