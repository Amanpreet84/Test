using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IDeductionRate
    {
        decimal Get(RelationType personType);
    }
}
