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
                if (arguments.valueOfX.HasValue && arguments.valueOfY.HasValue)
                {
                    arguments.result = function.valueOfA * Math.Pow(arguments.valueOfX.Value, function.functionPower) +
                                       function.valueOfB * Math.Pow(arguments.valueOfY.Value, function.functionPower - 1) +
                                       function.valueOfC;
                }
                else
                {
                    arguments.result = null;
                }
            }
        }
    }
}
