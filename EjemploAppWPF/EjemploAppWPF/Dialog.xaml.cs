using EjemploAppWPF.CarpetaDatos;
using EjemploAppWPF.CarpetaLogica;
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

namespace EjemploAppWPF
{
    /// <summary>
    /// Lógica de interacción para Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        private int errores;
        private Logica logica;
        public Datos datos;
        private int posicion;
        private Boolean modificar;
        public Dialog(Logica logica) //constructor si lo abrimos para añadir datos
        {
            InitializeComponent();
            this.logica = logica;
            datos = new Datos();
            this.DataContext= datos;
            modificar= false;
        }

        public Dialog(Logica logica, Datos datos, int posicion) //constructor si lo abrimos para modificar datos
        {
            InitializeComponent();
            this.logica = logica;
            this.datos = datos;
            this.posicion = posicion;
            this.DataContext = datos;
            modificar= true;
        }

        private void BT_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //cerramos la pestaña
        }

        private void BT_Registrar_Click(object sender, RoutedEventArgs e)
        {
            if(modificar) //el botón ejecuta un método u otro dependiendo si modificar es true o no
            {
                logica.modificar(datos, posicion); 
            }
            else
            {
                logica.aniadir(datos);
            }
            this.Close();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) //si se genera un error
            {
                errores++;
            }
            else //si desaparece
            {
                errores--;
            }

            if (errores == 0)
            {
                BT_Registrar.IsEnabled= true; //activa el botón de registro
            } else
            {
                BT_Registrar.IsEnabled= false; //desactiva el botón de registro
            }
        }
    }
}
