using FunctionApp.ViewModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FunctionApp.Model;

/// <summary>
///     Класс представляющий полиноминальную функцию
/// </summary>
public class PolynomialFunction : ViewModelBase
{
    /// <summary>
    ///     Степень функции
    /// </summary>
    private int _functionPower;

    /// <summary>
    ///     Вводимое пользователем значение A
    /// </summary>
    private double? _valueOfA;

    /// <summary>
    ///     Вводимое пользователем значение B
    /// </summary>
    private double? _valueOfB;

    /// <summary>
    ///     Выбираемое пользователем значение С
    /// </summary>
    private double? _valueOfC;

    /// <summary>
    ///     Конструктор функции
    /// </summary>
    /// <param name="power">Степень функции</param>
    public PolynomialFunction(int power)
    {
        ArgumentsList.CollectionChanged += OnArgumentsListChanged;
        FunctionPower = power;
        for (var i = 1; i <= 5; i++) PossibleValuesOfC.Add(i * Math.Pow(10, FunctionPower - 1));
        ValueOfC = PossibleValuesOfC.FirstOrDefault();
    }

    /// <summary>
    ///     Конструктор _valueOfA
    /// </summary>
    public double? ValueOfA
    {
        get => _valueOfA;
        set
        {
            _valueOfA = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Конструктор _valueOfB
    /// </summary>
    public double? ValueOfB
    {
        get => _valueOfB;
        set
        {
            _valueOfB = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Конструктор _valueOfC
    /// </summary>
    public double? ValueOfC
    {
        get => _valueOfC;
        set
        {
            _valueOfC = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Коллекция аргументов X и Y функции
    /// </summary>
    public ObservableCollection<Arguments> ArgumentsList { get; set; } = [];

    /// <summary>
    ///     Список со всеми возможными значениями коэффицента C
    /// </summary>
    public List<double?> PossibleValuesOfC { get; set; } = [];

    /// <summary>
    ///     Конструктор степени функции
    /// </summary>
    public int FunctionPower
    {
        get => _functionPower;
        set
        {
            if (value < 0 || value > 5)
                throw new ArgumentException("Function can only have power from 1 to 5.");
            _functionPower = value;
        }
    }

    /// <summary>
    ///     Проверка значений на null
    /// </summary>
    /// <returns>Наличие или отсутсвие значения каждого коэффицента</returns>
    public bool AreValuesSet()
    {
        return ValueOfA.HasValue && ValueOfB.HasValue && ValueOfC.HasValue;
    }

    /// <summary>
    ///     Обработчик события изменения argumentsList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnArgumentsListChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (e.NewItems == null) break;

                foreach (var item in e.NewItems)
                    if (item is Arguments arguments)
                        arguments.PropertyChanged += OnArgumentsChanged;

                break;

            case NotifyCollectionChangedAction.Remove:
                if (e.OldItems == null) break;

                foreach (var item in e.OldItems)
                    if (item is Arguments arguments)
                        arguments.PropertyChanged -= OnArgumentsChanged;

                break;
        }
    }

    /// <summary>
    ///     Обработчик события изменения члена-типа arguments
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnArgumentsChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(e.PropertyName);
    }
}