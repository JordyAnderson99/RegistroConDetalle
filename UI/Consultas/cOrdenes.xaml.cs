using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroConDetalle.BLL;
using RegistroConDetalle.Entidades;

namespace RegistroConDetalle.UI.Consultas
{
    /// <summary>
    /// Interaction logic for rPersonas.xaml
    /// </summary>
    public partial class cOrdenes : Window
    {
        Ordenes ordenes = new Ordenes();

        public cOrdenes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Ordenes> listado = new List<Ordenes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = OrdenesBLL.GetList(p => p.OrdenId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                }
            }
            else
            {
                listado = OrdenesBLL.GetList(c => true);
            }
            if (DesdeDatePicker.SelectedDate != null)
                listado = (List<Ordenes>)OrdenesBLL.GetList(p => p.Fecha.Date >= DesdeDatePicker.SelectedDate);
            if (HastaDatePicker.SelectedDate != null)
                listado = (List<Ordenes>)OrdenesBLL.GetList(p => p.Fecha.Date <= HastaDatePicker.SelectedDate);

            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = listado;
        }
    }
}