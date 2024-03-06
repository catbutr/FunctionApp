using System.ComponentModel;
using System.Runtime.CompilerServices;

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
