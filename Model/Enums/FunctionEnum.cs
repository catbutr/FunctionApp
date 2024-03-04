using System.ComponentModel;

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
