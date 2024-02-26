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
    ///  Класс представляющий полиноминальную функцию 
    /// </summary>
    public partial class PolynomialFunction : INotifyPropertyChanged
    {

        /// <summary>
        /// Вводимое пользователем значение A
        /// </summary>
        private double? _valueOfA;

        /// <summary>
        /// Конструктор _valueOfA
        /// </summary>
        public double? valueOfA
        {
            get { return _valueOfA; }
            set
            {
                _valueOfA = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вводимое пользователем значение B
        /// </summary>
        private double? _valueOfB;

        /// <summary>
        /// Конструктор _valueOfB
        /// </summary>
        public double? valueOfB
        {
            get { return _valueOfB; }
            set
            {
                _valueOfB = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбираемое пользователем значение С 
        /// </summary>
        private double? _valueOfC;

        /// <summary>
        /// Конструктор _valueOfC
        /// </summary>
        public double? valueOfC
        {
            get { return _valueOfC; }
            set
            {
                _valueOfC = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Коллекция аргументов X и Y функции
        /// </summary>
        public ObservableCollection<Arguments> argumentsList { get; set; }

        /// <summary>
        /// Список со всеми возможными значениями коэффицента C
        /// </summary>
        public List<double?> possibleValuesOfC { get; set;}

        /// <summary>
        /// Степень функции
        /// </summary>
        private int _functionPower;

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

        /// <summary>
        /// Проверка значений на null 
        /// </summary>
        /// <returns>Наличие или отсутсвие значения каждого коэффицента</returns>
        public bool AreValuesSet()
        {
            return valueOfA.HasValue && valueOfB.HasValue && valueOfC.HasValue;
        }

        /// <summary>
        /// Конструктор функции
        /// </summary>
        /// <param name="power">Степень функции</param>
        public PolynomialFunction(int power)
        {
            argumentsList = new ObservableCollection<Arguments>();
            argumentsList.CollectionChanged += OnArgumentsListChanged;
            functionPower = power;
            possibleValuesOfC = new List<double?>();
            for (int i = 1; i <= 5; i++)
            {
                possibleValuesOfC.Add(i * Math.Pow(10, functionPower - 1));
            }
            valueOfC = possibleValuesOfC.FirstOrDefault();
        }

        /// <summary>
        /// Обработчик события изменения argumentsList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Обработчик события изменения члена-типа arguments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnArgumentsChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        /// <summary>
        /// Обработчик события изменения свойства класса
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
