using FunctionApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FunctionApp.Converters
{
    /// <summary>
    /// Конвертация FunctionEnum в int
    /// </summary>
    public class EnumConverter : IValueConverter
    {
        /// <summary>
        /// Конвертация
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is int ? GetDescription((FunctionEnum)value) : DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// Обратная конвертация
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        /// <summary>
        /// Получение значения описания
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        private static string GetDescription(Enum enumValue)
        {
            Type type = enumValue.GetType();
            MemberInfo[] memInfo = type.GetMember(enumValue.ToString());

            if (memInfo.Length <= 0)
            {
                return enumValue.ToString();
            }

            object[] attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : enumValue.ToString();
        }
    }
}
