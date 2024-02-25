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
    public partial class Arguments: INotifyPropertyChanged
    {
        /// <summary>
        /// Вводимое пользователем значение X и его конструктор
        /// </summary>
        private double? _valueOfX;

        public double? valueOfX
        {
            get { return _valueOfX; }
            set { _valueOfX = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вводимое пользователем значение Y и его конструктор
        /// </summary>
        private double? _valueOfY;

        public double? valueOfY
        {
            get { return _valueOfY; }
            set
            {
                _valueOfY = value;
                OnPropertyChanged();
            }
        }
        private double? _result;

        public double? result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
