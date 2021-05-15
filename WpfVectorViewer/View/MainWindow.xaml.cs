using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfVectorViewer.ViewModel;

namespace WpfVectorViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private PrimitiveShapesViewModel _viewModel;
        public MainWindow(PrimitiveShapesViewModel viewModel) 
        {
            _viewModel = viewModel;

            InitializeComponent();
            DataContext = _viewModel;

            Loaded += (sender, e) =>
            {
                _viewModel.UpdateScale(mainGrid.ActualHeight, mainGrid.ActualWidth);
                
            };

            SizeChanged += (sender, e) =>
            {
                _viewModel.UpdateScale(mainGrid.ActualHeight, mainGrid.ActualWidth);
            };

        }

        private void mainGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _viewModel.DisplayDetails((e.OriginalSource as FrameworkElement).DataContext);
        }
    }
}
