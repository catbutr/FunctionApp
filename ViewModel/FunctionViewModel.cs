using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using FunctionApp.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FunctionApp.ViewModel
{
    public partial class FunctionViewModel : ObservableObject
    {
        [ObservableProperty]
        public PolynomialFunction selectedFunction;

        public ObservableCollection<PolynomialFunction> functions { get; set; }

        public FunctionViewModel()
        {
            functions = new ObservableCollection<PolynomialFunction>();

            for (int i = 1; i <= 5; i++)
            {
                var function = new PolynomialFunction(i);
                functions.Add(function);
            }

            selectedFunction = functions.First();
        }

    }
}
