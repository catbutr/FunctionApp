using FunctionApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Services
{
    public class FunctionSolverService
    {
        public void Calculate(PolynomialFunction function)
        {
            if (!function.AreCoefficientsSet())
            {
                return;
            }

            foreach (Arguments arguments in function.argumentsList)
            {
                if (arguments.XValue.HasValue && arguments.YValue.HasValue)
                {
                    arguments.Result = function.AValue * Math.Pow(arguments.XValue.Value, function.functionPower) +
                                       function.BValue * Math.Pow(arguments.YValue.Value, function.functionPower - 1) +
                                       function.CValue;
                }
                else
                {
                    arguments.Result = null;
                }
            }
        }
    }
}
