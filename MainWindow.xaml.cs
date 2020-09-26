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
using Registro_prestamo.UI.Registros;

namespace Registro_prestamo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rPrestamosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos rPrestamos = new rPrestamos();
            rPrestamos.Show();
        }

        private void rPersonasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPersonas rPersonas = new rPersonas();
            rPersonas.Show();
        }
    }
}