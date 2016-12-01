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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Negocio;
using System.Data;

namespace MiEstacionamiento
{
    /// <summary>
    /// Lógica de interacción para Lista.xaml
    /// </summary>
    public partial class EstacionamientosDisponibles : MetroWindow
    {

        public bool consultor=false;
        
        public EstacionamientosDisponibles()
        {
            InitializeComponent();
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (consultor)
            {
                CargarListar();
                dataLista.Columns.RemoveAt(6);
                btnEliminar.IsEnabled = false;
                btnModifica.IsEnabled = false;
                btnVolver1.IsEnabled = false;
                btnBuscar.IsEnabled = false;

            }
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Listando Estacionamientos");
                ProgressAlert.SetIndeterminate(); //Infinite
                await Task.Delay(2000);
                await ProgressAlert.CloseAsync();
                CargarListar();
            }
            catch (Exception ex)
            {
                string log = ex.Message;
               await this.ShowMessageAsync("Problema de conexión :(", "Contactar a supervisor");
            }




        }

        private void CargarListar()
        {
            ApiOperacion ops = new ApiOperacion();
            Estacionamiento datos = ops.listarDisponibles();
            dataLista.ItemsSource = datos.result;

            dataLista.Columns.RemoveAt(14);
            dataLista.Columns.RemoveAt(13);
            dataLista.Columns.RemoveAt(11);
            dataLista.Columns.RemoveAt(9);
            dataLista.Columns.RemoveAt(8);
            dataLista.Columns.RemoveAt(7);
            dataLista.Columns.RemoveAt(1);







        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void dataLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             

        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Result usuarioSeleccionado = dataLista.SelectedItem as Result;
                string rut = usuarioSeleccionado.rutUsuario;
                ApiOperacion ops = new ApiOperacion();
                Usuario user = ops.Elminiar(rut);
                await this.ShowMessageAsync("Operación Realizada", "Se a eliminado al usuario");
                CargarListar();

            }
            catch (Exception ex)
            {
                string log = ex.Message;
                await this.ShowMessageAsync("Problema de conexión :(", "Contactar a supervisor");
            }




        }

        private void btnVolver1_Click(object sender, RoutedEventArgs e)
        {
            Menu _ver = new Menu();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private async void btnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (dataLista.SelectedItem!=null)
            {
                Result usuarioSeleccionado = dataLista.SelectedItem as Result;
                ModificacionUsuario _ver = new ModificacionUsuario();
                _ver.rutAModificar = usuarioSeleccionado.rutUsuario;
                _ver.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("Error!!", "Debe Seleccionar un usuario");

            }


        }

       
    }
}
