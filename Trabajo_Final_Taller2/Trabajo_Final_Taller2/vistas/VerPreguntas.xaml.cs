﻿using Entidades;
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

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Lógica de interacción para VerPreguntas.xaml
    /// </summary>
    public partial class VerPreguntas : Window
    {
        Usuario usuario;
        List<Pregunta> preguntas;

        public VerPreguntas(Usuario user, List<Pregunta> pregs)
        {
            InitializeComponent();
            usuario = user;
            preguntas = pregs;
            lbx_Preguntas.ItemsSource = pregs;
        }
     

        private void btn_Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnIrAPregunta_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_Preguntas.SelectedIndex != -1)
            {
                // Pregunta seleccionada
                Pregunta preguntaSelec = (Pregunta)lbx_Preguntas.SelectedItem;
                VistaPregunta vistaPregunta = new VistaPregunta(usuario, preguntaSelec);
                vistaPregunta.ShowDialog();
            }
        }

        private void Lbx_Preguntas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pregunta preguntaSelec = (Pregunta)lbx_Preguntas.SelectedItem;
            lbl_user.Content ="El usuario: "+ preguntaSelec.UserPregunta.Nombre;
            lbl_titulo.Content = preguntaSelec.Titulo;
            lbl_fecha.Content = "El día: "+preguntaSelec.Fecha;
        }
    }
}
