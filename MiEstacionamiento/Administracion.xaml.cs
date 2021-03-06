﻿using System;
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

namespace MiEstacionamiento
{
    /// <summary>
    /// Lógica de interacción para Administracion.xaml
    /// </summary>
    public partial class Administracion : MetroWindow
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            AddUser _ver = new AddUser();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            AddVeh _ver = new AddVeh();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void btnBuscarVeh_Click(object sender, RoutedEventArgs e)
        {
            EstacionamientosOcupados _ver = new EstacionamientosOcupados();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void tltSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEliminarVeh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListarEstacionamientos_Click(object sender, RoutedEventArgs e)
        {
            EstacionamientosDisponibles _ver = new EstacionamientosDisponibles();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void btnVolver1_Click(object sender, RoutedEventArgs e)
        {
            Menu _ver = new Menu();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }
    }
}
