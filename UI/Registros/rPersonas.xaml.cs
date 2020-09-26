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
    public partial class rPersonas : Window
    {
        private Personas Personas = new Personas();
        public rPersonas()
        {
            InitializeComponent();
            this.DataContext = Personas;
        }
        //Limpiar
        private void Limpiar()
        {
            this.Personas = new Personas();
            this.DataContext = Personas;
        }
        //Validar        
        private bool Validar()
        {
            bool Validado = true;
            if (PersonaIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Validado;
        }
        //Buscar
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var personas = PersonasBLL.Buscar(Utilidades.ToInt(PersonaIdTextBox.Text));

            if (personas != null)
                this.Personas = personas;
            else
                this.Personas = new Personas();

            this.DataContext = this.Personas;
        }
        //Nuevo
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            PersonaIdTextBox.SelectAll();
            PersonaIdTextBox.Focus();
        }
        //Guardar
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = PersonasBLL.Guardar(Personas);
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
                if (PersonasBLL.Eliminar(Utilidades.ToInt(PersonaIdTextBox.Text)))
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