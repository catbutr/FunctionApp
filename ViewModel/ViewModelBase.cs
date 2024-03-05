using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.ViewModel
{
    /// <summary>
    /// Базовый класс ViewModel
    /// </summary>
    public class ViewModelBase:INotifyPropertyChanged
    {
        /// <summary>
        ///     Событие изменения свойства класса
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Обработчик события изменения свойства класса
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
