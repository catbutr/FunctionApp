using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FunctionApp.Model;

/// <summary>
///     Представление выводимых в таблицу аргументов X и Y полиминальной функции, а также её решение
/// </summary>
public class Arguments : INotifyPropertyChanged
{
    /// <summary>
    ///     Результат вычисления полиноминальной функции
    /// </summary>
    private double? _result;

    /// <summary>
    ///     Вводимое пользователем значение X
    /// </summary>
    private double? _valueOfX;

    /// <summary>
    ///     Вводимое пользователем значение Y
    /// </summary>
    private double? _valueOfY;

    /// <summary>
    ///     Конструктор _valueOfX
    /// </summary>
    public double? ValueOfX
    {
        get => _valueOfX;
        set
        {
            _valueOfX = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Конструктор _valueOfY
    /// </summary>
    public double? ValueOfY
    {
        get => _valueOfY;
        set
        {
            _valueOfY = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Конструктор _result
    /// </summary>
    public double? Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Событие изменения свойства класса
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    ///     Обработчик события изменения свойства класса
    /// </summary>
    /// <param name="propertyName"></param>
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}