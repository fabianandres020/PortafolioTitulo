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
            errorMarca.Text = string.Empty;
            errorModelo.Text = string.Empty;
            var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Ingresando Modelo....");
            ProgressAlert.SetIndeterminate(); //Infinite
            try
            {
                string marca = txtMarca.Text.Trim();
                if(marca.Length==0 )
                {
                    await ProgressAlert.CloseAsync();
                    errorMarca.Text = "Debe Ingresar Datos";
                    txtMarca.Focus();
                }
                else
                {
                    ApiOperacion ops = new ApiOperacion();
                    Marca _marca = ops.IngresarMarca(marca);
                    if(_marca.response)
                    {
                        await Task.Delay(2000);
                        await ProgressAlert.CloseAsync();
                        await this.ShowMessageAsync("Exito", "Ingreso exitoso");
                        txtMarca.Text = string.Empty;
                        txtMarca.Focus();
                    }
                    else
                    {
                        await Task.Delay(1000);
                        await ProgressAlert.CloseAsync();
                        string mensaje = _marca.msg.ToString();
                        await this.ShowMessageAsync("Error", mensaje);
                        txtMarca.Text = string.Empty;
                        txtMarca.Focus();
                    }
                    
                }
                
                   
              
            }
            catch (Exception)
            {

                await this.ShowMessageAsync("Error de Conexcion", "Contacte al administrador");
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

                Marca marca_modelo = ops.listarMarcaYModelo();
               

               // dataMarca.ItemsSource = marca.listaMarcaVehiculo;
            }
            catch (Exception)
            {

            }
           

          }

        private async void btnMarca_Click(object sender, RoutedEventArgs e)
        {
            errorMarca.Text = string.Empty;
            errorModelo.Text = string.Empty;
            var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Ingresando Modelo....");
            ProgressAlert.SetIndeterminate(); //Infinite
            try
            {
                string modelo = txtModelo.Text.Trim();
               
                if (cbModelo.SelectedIndex==-1)
                {
                    await ProgressAlert.CloseAsync();
                    errorModelo.Text = "Debe Ingresar Datos";
                    cbModelo.Focus();
                }
                else if (modelo.Length == 0)
                {
                  
                    await ProgressAlert.CloseAsync();
                    errorModelo.Text = "Debe Ingresar Datos";
                    txtModelo.Focus();
                }
                else
                {
                    int idmarca = (int)cbModelo.SelectedValue;
                    ApiOperacion ops = new ApiOperacion();
                    Modelo _modelo = ops.IngresarModelo(modelo,idmarca);
                    if(_modelo.response)
                    {
                        await Task.Delay(2000);
                        await ProgressAlert.CloseAsync();
                        await this.ShowMessageAsync("Exito", "Ingreso de modelo completado");
                        txtModelo.Text = string.Empty;
                        txtModelo.Focus();
                    }
                    else
                    {
                        txtModelo.Text = string.Empty;
                        await Task.Delay(1000);
                        await ProgressAlert.CloseAsync();
                        string mensaje = _modelo.msg.ToString();
                        await this.ShowMessageAsync("Error", mensaje);
                        txtModelo.Focus();
                    }


                }
   
            }
            catch (Exception)
            {
                await Task.Delay(1000);
                await ProgressAlert.CloseAsync();
                await this.ShowMessageAsync("Error de Conexcion", "Conctactar al administrador");
                txtModelo.Focus();

            }
        }
    }
}
