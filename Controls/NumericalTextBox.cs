using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace FunctionApp.Controls
{
    /// <summary>
    /// Класс текстового поля, принимающего исключительно числовые значения 
    /// </summary>
    public class NumericalTextBox:TextBox
    {
        /// <summary>
        /// Переопределения метода OnKeyDown 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            bool b = false;
            switch (e.Key)
            {
                case Key.Back: b = true; break;
                case Key.D0: b = true; break;
                case Key.D1: b = true; break;
                case Key.D2: b = true; break;
                case Key.D3: b = true; break;
                case Key.D4: b = true; break;
                case Key.D5: b = true; break;
                case Key.D6: b = true; break;
                case Key.D7: b = true; break;
                case Key.D8: b = true; break;
                case Key.D9: b = true; break;
                case Key.OemPeriod: b = true; break;
            }
            if (b == false)
            {
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Метод защиты от копирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            var data = e.SourceDataObject.GetData(DataFormats.Text);
            if (!IsValidNumericInput(data.ToString()))
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// Метод проверки на числовое значение при помощи регулярных выражений
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsValidNumericInput(string input)
        {
            const string numericPattern = @"^-?[0-9]*(?:\.[0-9]*)?$";
            return Regex.IsMatch(input, numericPattern);
        }
    }
}
