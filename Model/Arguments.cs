﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        private double? xValue;

        public double? XValue
        {
            get { return xValue; }
            set { xValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вводимое пользователем значение Y и его конструктор
        /// </summary>
        private double? yValue;

        public double? YValue
        {
            get { return yValue; }
            set
            {
                yValue = value;
                OnPropertyChanged();
            }
        }
        private double? result;

        public double? Result
        {
            get { return result; }
            set
            {
                result = value;
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
