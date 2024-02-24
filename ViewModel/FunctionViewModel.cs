using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using FunctionApp.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FunctionApp.ViewModel
{
    public partial class FunctionViewModel : INotifyPropertyChanged
    {
        private PolynomialFunction selectedFunction;

        public PolynomialFunction SelectedFunction
        {
            get => selectedFunction;
            set
            {
                selectedFunction = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PolynomialFunction> functions;

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

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
