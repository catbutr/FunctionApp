using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FunctionApp.Model
{
    /// <summary>
    ///  Класс представляющий базовую функцию 
    /// </summary>
    public class Function
    {
        /// <summary>
        /// Вводимое пользователем значение X и его конструктор
        /// </summary>
        public double xValue { get; set; } = 0;

        /// <summary>
        /// Вводимое пользователем значение Y и его конструктор
        /// </summary>
        public double yValue { get; set; } = 0;

        /// <summary>
        /// Вводимое пользователем значение A и его конструктор
        /// </summary>
        public double aValue {  get; set; } = 0;

        /// <summary>
        /// Вводимое пользователем значение B и его конструктор
        /// </summary>
        public double bValue { get; set; } = 0;

        /// <summary>
        /// Выбираемое пользователем значение С 
        /// </summary>
        public int cValue { get; set; } = 0;

        public Function(double x, double y, double a, double b, int c, int power)
        {
            xValue = x;
            yValue = y;
            aValue = a;
            bValue = b;
            cValue = c;
            functionPower = power;
        }

        /// <summary>
        /// Степень функции
        /// </summary>
        private int _functionPower;

        /// <summary>
        /// Конструктор степени функции
        /// </summary>
        public int functionPower
        {
            get { return _functionPower;}
            set 
            {
                if (value < 0 || value > 5)
                    throw new ArgumentException("Function can only have power from 1 to 5.");
                _functionPower = value; 
            }
        }

        /// <summary>
        /// Решение функции
        /// </summary>
        /// <returns>Возвращает решение функции в формале double</returns>
        public double solution()
        {
            double solution = (aValue *Math.Pow(xValue,functionPower)) + (bValue * Math.Pow(yValue, functionPower - 1)) + cValue;
            return solution;

        }


    }
}
