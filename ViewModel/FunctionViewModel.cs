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
        public string testString = "sadsadd";


        [ObservableProperty]
        private ObservableCollection<Function> _functions;

        public ObservableCollection<Function> functions
        {
            get { return _functions; }
            set { SetProperty(ref _functions, value); }
        }
        private void LoadFunctions()
        {
        }
        public FunctionViewModel() => LoadFunctions();
    }
}
