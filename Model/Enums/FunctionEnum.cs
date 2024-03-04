using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp.Model.Enums
{
    /// <summary>
    /// Перечисляемый тип названий полиномиальной функции
    /// </summary>
    public enum FunctionEnum
    {
        [Description("Линейная функция")]
        One = 1,

        [Description("Квадратическая функция")]
        Two = 2,

        [Description("Функция третьей степени")]
        Three = 3,

        [Description("Функция четвертой степени")]
        Four = 4,

        [Description("Функция пятой степени")]
        Five = 5,
    }
}
