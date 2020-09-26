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
using Registro_prestamo.BLL;
using Registro_prestamo.Entidades;

namespace Registro_prestamo.UI.Registros
{
    public partial class rPrestamos : Window
    {
        private Prestamos Prestamos = new Prestamos();
        public rPrestamos()
        {
            InitializeComponent();
            this.DataContext = Prestamos;
        }
        //Limpiar
        private void Limpiar()
        {
            this.Prestamos = new Prestamos();
            this.DataContext = Prestamos;
        }
        //Validar        
        private bool Validar()
        {
            bool Validado = true;
            if (PrestamoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Validado;
        }
        //Buscar
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamos = PrestamosBLL.Buscar(Utilidades.ToInt(PrestamoIdTextBox.Text));

            if (prestamos != null)
                this.Prestamos = prestamos;
            else
                this.Prestamos = new Prestamos();

            this.DataContext = this.Prestamos;
        }
        //Nuevo
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            PrestamoIdTextBox.SelectAll();
            PrestamoIdTextBox.Focus();
        }
        //Guardar
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = PrestamosBLL.Guardar(Prestamos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transacción Exitosa", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Eliminar
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PrestamosBLL.Eliminar(Utilidades.ToInt(PrestamoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}