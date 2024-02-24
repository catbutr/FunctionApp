using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Enums
{
    public enum FunctionEnum
    {
        [Description("Линейная функция")]
        First = 1,

        [Description("Квадратическая функция")]
        Second = 2,

        [Description("Функция третьей степени")]
        Third = 3,

        [Description("Функция четвертой степени")]
        Forth = 4,

        [Description("Функция пятой степени")]
        Fifth = 5,
    }
}
