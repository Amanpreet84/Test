using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise
{
    public class NinjectResolver : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<BusinessLayer.IDeductionCalc>().To<BusinessLayer.DeductionCalc>();
            Bind<BusinessLayer.IDeductionRate>().To<BusinessLayer.DeductionRate>();
            Bind<BusinessLayer.IDiscountCalc>().To<BusinessLayer.DiscountCalc>();
            Bind<ICalculationService>().To<CalculationService>();
        }
    }
}