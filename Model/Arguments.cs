using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Model
{
    public partial class Arguments: ObservableObject
    {
        /// <summary>
        /// Вводимое пользователем значение X и его конструктор
        /// </summary>
        [ObservableProperty]
        private double xValue;

        /// <summary>
        /// Вводимое пользователем значение Y и его конструктор
        /// </summary>
        [ObservableProperty]
        public double yValue;

        public Arguments(double x, double y)
        {
            xValue = x;
            yValue = y;
        }

        /// <summary>
        /// Решение функции
        /// </summary>
        /// <returns>Возвращает решение функции в формале double</returns>
        //public double solution()
        //{
            //double solution = (aValue * Math.Pow(xValue, functionPower)) + (bValue * Math.Pow(yValue, functionPower - 1)) + cValue;
            //return solution;
        //}
    }
}
