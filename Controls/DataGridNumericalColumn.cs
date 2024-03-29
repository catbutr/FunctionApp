﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FunctionApp.Controls;

/// <summary>
///     Класс колонки DataGrid, принимающий только числовые значения
/// </summary>
public partial class DataGridNumericalColumn : DataGridTextColumn
{
    /// <summary>
    /// Регулярное выражение для численного ввода
    /// </summary>
    /// <returns></returns>
    [GeneratedRegex(@"^-?[0-9]*(?:\.[0-9]*)?$")]
    private static partial Regex NumericPattern();

    /// <summary>
    ///     Переопределение события перехода ячейки в режим правки
    /// </summary>
    /// <param name="editingElement"></param>
    /// <param name="editingEventArgs"></param>
    /// <returns></returns>
    protected override object? PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs? editingEventArgs)
    {
        var textBox = editingElement as TextBox;
        textBox!.PreviewTextInput += OnPreviewTextInput;
        DataObject.AddPastingHandler(textBox, OnPaste);
        return base.PrepareCellForEdit(editingElement, editingEventArgs);
    }

    /// <summary>
    ///     Метод проверки пользовательского ввода
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var textBox = (TextBox)sender;
        var proposedText = textBox.Text.Insert(textBox.CaretIndex, e.Text);
        if (!IsValidNumericInput(proposedText)) e.Handled = true;
    }

    /// <summary>
    ///     Метод защиты от копирования
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        var data = e.SourceDataObject.GetData(DataFormats.Text);
        if (!IsValidNumericInput(data!.ToString()!)) e.CancelCommand();
    }

    /// <summary>
    ///     Метод проверки на числовое значение при помощи регулярных выражений
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static bool IsValidNumericInput(string input)
    {
        return NumericPattern().IsMatch(input);
    }
}