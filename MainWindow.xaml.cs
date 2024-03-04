using FunctionApp.ViewModel;
using System.Windows;

namespace FunctionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var functionViewModel = new FunctionViewModel();
            DataContext = functionViewModel; 
        }
    }
}