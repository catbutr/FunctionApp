using FunctionApp.Model;

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

            foreach (Arguments arguments in function.ArgumentsList)
            {
                if (arguments.ValueOfX.HasValue && arguments.ValueOfY.HasValue)
                {
                    arguments.Result = function.ValueOfA * Math.Pow(arguments.ValueOfX.Value, function.FunctionPower) +
                                       function.ValueOfB * Math.Pow(arguments.ValueOfY.Value, function.FunctionPower - 1) +
                                       function.ValueOfC;
                }
                else
                {
                    arguments.Result = null;
                }
            }
        }
    }
}
