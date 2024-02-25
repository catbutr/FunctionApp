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
using FunctionApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FunctionApp.ViewModel
{
    public partial class FunctionViewModel : INotifyPropertyChanged
    {
        private PolynomialFunction _selectedFunction;
        private readonly FunctionSolverService _solverService;
        public PolynomialFunction selectedFunction
        {
            get => _selectedFunction;
            set
            {
                _selectedFunction = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PolynomialFunction> functions { get; set; }

        public FunctionViewModel()
        {
            _solverService = new FunctionSolverService();
            functions = new ObservableCollection<PolynomialFunction>();

            for (int i = 1; i <= 5; i++)
            {
                var function = new PolynomialFunction(i);
                function.PropertyChanged += OnFunctionPropertyChanged;
                functions.Add(function);
            }

            _selectedFunction = functions.First();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnFunctionPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not PolynomialFunction function)
            {
                return;
            }

            if (e.PropertyName == nameof(Arguments.result))
            {
                return;
            }

            _solverService.Calculate(function);
            OnPropertyChanged(e.PropertyName);
        }
    }
}
