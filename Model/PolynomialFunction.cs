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
    public partial class PolynomialFunction : ObservableObject
    {

        /// <summary>
        /// Вводимое пользователем значение A и его конструктор
        /// </summary>
        [ObservableProperty]
        private double aValue;

        /// <summary>
        /// Вводимое пользователем значение B и его конструктор
        /// </summary>
        [ObservableProperty]
        private double bValue;

        /// <summary>
        /// Выбираемое пользователем значение С 
        /// </summary>
        [ObservableProperty]
        private double cValue;

        /// <summary>
        /// List of arguments
        /// </summary>
        [ObservableProperty]
        public ObservableCollection<Arguments> argumentsList;

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
