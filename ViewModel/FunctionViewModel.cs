using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FunctionApp.Model;
using FunctionApp.Services;

namespace FunctionApp.ViewModel;

/// <summary>
///     ViewModel для работы с полиномиальными функциями
/// </summary>
public class FunctionViewModel : INotifyPropertyChanged
{
    /// <summary>
    ///     Выбранная пользователем функция
    /// </summary>
    private PolynomialFunction _selectedFunction;

    /// <summary>
    ///     Конструктор класса
    /// </summary>
    public FunctionViewModel()
    {
        Functions = new ObservableCollection<PolynomialFunction>();

        for (var i = 1; i <= 5; i++)
        {
            var function = new PolynomialFunction(i);
            function.PropertyChanged += OnFunctionPropertyChanged;
            Functions.Add(function);
        }

        _selectedFunction = Functions.First();
    }

    /// <summary>
    ///     Конструктор _selectedFunction
    /// </summary>
    public PolynomialFunction SelectedFunction
    {
        get => _selectedFunction;
        set
        {
            _selectedFunction = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Коллекция значений полиминальных функций
    /// </summary>
    public ObservableCollection<PolynomialFunction> Functions { get; set; }

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

    /// <summary>
    ///     Обработчик события изменения полиномиальной функции
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnFunctionPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not PolynomialFunction function) return;

        if (e.PropertyName == nameof(Arguments.Result)) return;

        FunctionSolverService.Calculate(function);
        OnPropertyChanged(e.PropertyName);
    }
}