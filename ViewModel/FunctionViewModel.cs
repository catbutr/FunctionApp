using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using FunctionApp.Model;

namespace FunctionApp.ViewModel
{
    public partial class FunctionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Function> _functions;
        public ObservableCollection<Function> functions
        {
            get { return _functions; }
            set { SetProperty(ref _functions, value); }
        }
        private void LoadFunctions()
        {
            functions = new ObservableCollection<Function>
            {
                new Function(1,2,3,4,5,1),
                new Function(1,2,3,4,5,2),
                new Function(1,2,3,4,5,3),
                new Function(1,2,3,4,5,4),
                new Function(1,2,3,4,5,5)
            };
        }
        public FunctionViewModel() => LoadFunctions();
    }
}
