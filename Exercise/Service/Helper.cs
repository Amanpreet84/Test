using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Ninject;

namespace Exercise
{
    public class Helper
    {
        public static string getInstance(Employee emp)
        {
            StandardKernel _kernal = new StandardKernel();

            _kernal.Load(Assembly.GetExecutingAssembly());

            BusinessLayer.IDeductionCalc _ideductionCalc = _kernal.Get<BusinessLayer.IDeductionCalc>();

            CalculationService objCalc = new CalculationService(_ideductionCalc);

            CalculationResults results = objCalc.CalculateDeductions(emp);

            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("<table class=\"table\">");
            sb.Append("<tr>");
            sb.Append("<th>Dependent Deduction</th>");
            sb.Append("<th>Dependent Deduction / Year</th>");
            sb.Append("<th>Emp Deduction/PayCheck</th>");
            sb.Append("<th>Employee Yearly Pay After Ded</th>");
            sb.Append("<th>Total Deduction/ PayCheck</th>");
            sb.Append("<th>Total Deduction/ Year</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>" + results.DependentsDeductionPerPayCheck.ToString("#.##") + "</td>");
            //sb.Append("</tr>");
            //sb.Append("<tr>");
            sb.Append("<td>" + results.DependentsDeductionPerYear.ToString("#.##") + "</td>");
            //sb.Append("</tr>");
            //sb.Append("<tr>");
            sb.Append("<td>" + results.EmployeeDeductionPerPayCheck.ToString("#.##") + "</td>");
            //sb.Append("</tr>");
            //sb.Append("<tr>");
            sb.Append("<td>" + results.EmployeeYearlyPayAfterDeductions.ToString("#.##") + "</td>");
            //sb.Append("</tr>");
            //sb.Append("<tr>");
            sb.Append("<td>" + results.TotalDeductionPerPayCheck.ToString("#.##") + "</td>");
            //sb.Append("</tr>");
            //sb.Append("<tr>");
            sb.Append("<td>" + results.TotalDeductionPerYear.ToString("#.##") + "</td>");
            //sb.Append("</tr>");
            sb.Append("</table>");
            return sb.ToString();
        }        
    }
}