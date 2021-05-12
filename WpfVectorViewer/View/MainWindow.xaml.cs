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
        public MainWindow(PrimitiveShapesViewModel viewModel)
        {
            InitializeComponent();
            gridName.RenderTransform = new ScaleTransform(0.5, 0.5);
            DataContext = viewModel;
        }
    }
}
