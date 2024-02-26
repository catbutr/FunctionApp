using FunctionApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Services
{
    /// <summary>
    /// Сервис по решению функций
    /// </summary>
    public class FunctionSolverService
    {
        /// <summary>
        /// Метод расчёт значения функции
        /// </summary>
        /// <param name="function">Полиноминальная функция</param>
        public void Calculate(PolynomialFunction function)
        {
            if (!function.AreValuesSet())
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
