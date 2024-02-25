using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Model
{
    /// <summary>
    /// Представление выводимых в таблицу аргументов X и Y полиминальной функции, а также её решение
    /// </summary>
    public partial class Arguments: INotifyPropertyChanged
    {
        /// <summary>
        /// Вводимое пользователем значение X
        /// </summary>
        private double? _valueOfX;

        /// <summary>
        /// Конструктор _valueOfX
        /// </summary>
        public double? valueOfX
        {
            get { return _valueOfX; }
            set 
            { 
                _valueOfX = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вводимое пользователем значение Y
        /// </summary>
        private double? _valueOfY;

        /// <summary>
        /// Конструктор _valueOfY
        /// </summary>
        public double? valueOfY
        {
            get { return _valueOfY; }
            set
            {
                _valueOfY = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Результат вычисления полиноминальной функции
        /// </summary>
        private double? _result;

        /// <summary>
        /// Конструктор _result
        /// </summary>
        public double? result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
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
    }
}
