using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FunctionApp.Model
{
    /// <summary>
    ///  Класс представляющий базовую функцию 
    /// </summary>
    public class PolynomialFunction : ObservableObject
    {

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
        public double cValue { get; set; } = 0;

        /// <summary>
        /// List of arguments
        /// </summary>
        public ObservableCollection<Arguments> ArgumentsList { get; set; }

        /// <summary>
        /// Available C coefficients
        /// </summary>
        public List<double> availableCoefficientsOfC { get; set;}

        /// <summary>
        /// Степень функции
        /// </summary>
        private int _functionPower;

        public ObservableCollection<int> possibleValuesOfC;

        /// <summary>
        /// Конструктор степени функции
        /// </summary>
        public int functionPower
        {
            get { return _functionPower; }
            set
            {
                if (value < 0 || value > 5)
                    throw new ArgumentException("Function can only have power from 1 to 5.");
                _functionPower = value;
            }
        }

        public PolynomialFunction(int power)
        {
            ArgumentsList = new ObservableCollection<Arguments>();
            functionPower = power;
            availableCoefficientsOfC = new List<double>();

            for (int i = 1; i <= 5; i++)
            {
                availableCoefficientsOfC.Add(i * Math.Pow(10, functionPower - 1));
            }

            cValue = availableCoefficientsOfC.FirstOrDefault();
        }
    }
}
