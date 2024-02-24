using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FunctionApp.Model
{
    /// <summary>
    ///  Класс представляющий базовую функцию 
    /// </summary>
    public partial class PolynomialFunction : INotifyPropertyChanged
    {

        /// <summary>
        /// Вводимое пользователем значение A и его конструктор
        /// </summary>
        private double? aValue;

        public double? AValue
        {
            get { return aValue; }
            set
            {
                aValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вводимое пользователем значение B и его конструктор
        /// </summary>
        private double? bValue;
        public double? BValue
        {
            get { return bValue; }
            set
            {
                bValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбираемое пользователем значение С 
        /// </summary>
        private double? cValue;

        public double? CValue
        {
            get { return cValue; }
            set
            {
                cValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// List of arguments
        /// </summary>
        public ObservableCollection<Arguments> argumentsList { get; set; }

        /// <summary>
        /// Available C coefficients
        /// </summary>
        public List<double?> availableCoefficientsOfC { get; set;}

        /// <summary>
        /// Степень функции
        /// </summary>
        private int _functionPower;

        public List<int> possibleValuesOfC;

        public event PropertyChangedEventHandler? PropertyChanged;

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

        public bool AreCoefficientsSet()
        {
            return AValue.HasValue && BValue.HasValue && CValue.HasValue;
        }

        public PolynomialFunction(int power)
        {
            argumentsList = new ObservableCollection<Arguments>();
            argumentsList.CollectionChanged += OnArgumentsListChanged;
            functionPower = power;
            availableCoefficientsOfC = new List<double?>();

            for (int i = 1; i <= 5; i++)
            {
                availableCoefficientsOfC.Add(i * Math.Pow(10, functionPower - 1));
            }

            cValue = availableCoefficientsOfC.FirstOrDefault();
        }

        private void OnArgumentsListChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems == null)
                    {
                        break;
                    }

                    foreach (object item in e.NewItems)
                    {
                        if (item is Arguments arguments)
                        {
                            arguments.PropertyChanged += OnArgumentsChanged;
                        }
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems == null)
                    {
                        break;
                    }

                    foreach (object item in e.OldItems)
                    {
                        if (item is Arguments arguments)
                        {
                            arguments.PropertyChanged -= OnArgumentsChanged;
                        }
                    }

                    break;
            }
        }

        private void OnArgumentsChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
