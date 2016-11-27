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

namespace MiEstacionamiento
{
    /// <summary>
    /// Lógica de interacción para AddVeh.xaml
    /// </summary>
    public partial class AddVeh : MetroWindow
    {
        public AddVeh()
        {
            InitializeComponent();
        }

        private async void btnGuardarVeh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string marca = txtMarca.Text.Trim();
                if(marca.Length==0 )
                {
                    errorMarca.Text = "Debe Ingresar Datos";
                }
                else
                {
                    ApiOperacion ops = new ApiOperacion();
                    Marca _marca = ops.IngresarMarca(marca);

                    await this.ShowMessageAsync("Exito", "Ingreso exitosa");
                }
                
                   
              
            }
            catch (Exception)
            {

                await this.ShowMessageAsync("Ingreso Erroneo", "Asegura ingreso de un usuario y/o propietario existente");
            }


        }

        private void btnVolver1_Click(object sender, RoutedEventArgs e)
        {
            Administracion _ver = new Administracion();
            this.Close();
            _ver.ShowDialog();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiOperacion ops = new ApiOperacion();
                Marca marca = ops.listarMarca();
                cbModelo.SelectedValuePath = "idMarca";
                cbModelo.DisplayMemberPath = "nombre";
                cbModelo.ItemsSource = marca.listaMarcaVehiculo;
                dataMarca.ItemsSource = marca.listaMarcaVehiculo;
            }
            catch (Exception)
            {

            }
           

          }

        private async void btnMarca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string modelo = txtModelo.Text.Trim();
                int idmarca = (int)cbModelo.SelectedValue;
                
                if (modelo.Length == 0)
                {
                    errorModelo.Text = "Debe Ingresar Datos";
                }
                else
                {
                    ApiOperacion ops = new ApiOperacion();
                    Modelo _modelo = ops.IngresarModelo(modelo,idmarca);

                    await this.ShowMessageAsync("Exito", "Ingreso exitosa");
                }



            }
            catch (Exception)
            {

                await this.ShowMessageAsync("Ingreso Erroneo", "Asegura ingreso de un usuario y/o propietario existente");
            }
        }
    }
}
