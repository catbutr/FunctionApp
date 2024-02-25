using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using FunctionApp.Model;
using FunctionApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FunctionApp.ViewModel
{
    /// <summary>
    /// ViewModel для работы с полиномиальными функциями
    /// </summary>
    public partial class FunctionViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Выбранная пользователем функция
        /// </summary>
        private PolynomialFunction _selectedFunction;

        /// <summary>
        /// Конструктор _selectedFunction
        /// </summary>
        public PolynomialFunction selectedFunction
        {
            get => _selectedFunction;
            set
            {
                _selectedFunction = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Сервис для вычисления значения полиминальной функции
        /// </summary>
        private readonly FunctionSolverService _solverService;

        /// <summary>
        /// Коллекция значений полиминальных функций 
        /// </summary>
        public ObservableCollection<PolynomialFunction> functions { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public FunctionViewModel()
        {
            _solverService = new FunctionSolverService();
            functions = new ObservableCollection<PolynomialFunction>();

            for (int i = 1; i <= 5; i++)
            {
                var function = new PolynomialFunction(i);
                function.PropertyChanged += OnFunctionPropertyChanged;
                functions.Add(function);
            }

            _selectedFunction = functions.First();
        }

        /// <summary>
        /// Событие изменения свойства класса
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Обработчик события изменения свойства класса
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Обработчик события изменения полиномиальной функции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFunctionPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not PolynomialFunction function)
            {
                return;
            }

            if (e.PropertyName == nameof(Arguments.result))
            {
                return;
            }

            _solverService.Calculate(function);
            OnPropertyChanged(e.PropertyName);
        }
    }
}
