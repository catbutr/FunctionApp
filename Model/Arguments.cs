using FunctionApp.ViewModel;

namespace FunctionApp.Model;

/// <summary>
///     Представление выводимых в таблицу аргументов X и Y полиминальной функции, а также её решение
/// </summary>
public class Arguments : ViewModelBase
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
}