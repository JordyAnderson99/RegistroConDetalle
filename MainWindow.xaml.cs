using System;
using System.Collections.Generic;
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
using RegistroConDetalle.UI.Registros;
//using RegistroConDetalle.UI.Consultas;

namespace RegistroConDetalle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroOrdenesButton_Click(object sender, RoutedEventArgs e){
            rOrdenes rOrd = new rOrdenes();
            rOrd.Show();
        }

        /*private void ConsultaOrdenesButton_Click(object sender, RoutedEventArgs e){
           cOrdenes cOrd = new cOrdenes();
            cOrd.Show();
        }*/
    }
}
