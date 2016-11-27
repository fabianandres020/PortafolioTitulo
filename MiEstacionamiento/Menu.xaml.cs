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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {

        public string bienvenida;
        public Menu()
        {
            InitializeComponent();
        }

        private void tltSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            ModificacionUsuario _ver = new ModificacionUsuario();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            Lista _ver = new Lista();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            Administracion _ver = new Administracion();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            //txtBienvenida.Text = bienvenida;
        }
    }
}
