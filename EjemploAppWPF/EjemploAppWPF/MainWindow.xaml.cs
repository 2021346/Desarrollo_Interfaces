using EjemploAppWPF.CarpetaDatos;
using EjemploAppWPF.CarpetaLogica;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EjemploAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Datos> listaDatos2 { get; set; } //se actualiza si añadimos registros, no como la lista
        public List<Datos> listaDatos { get; set; }

        private Logica logica;

        public MainWindow()
        {
            InitializeComponent();
            logica = new Logica();
            DG_ColumnasTrue.DataContext = this; //no importa si declaras el datacontext antes o después de crear el objeto, pero tiene que tener un atributo
            DG_ColumnasFalse.DataContext = this;
            DG_BindingLogica.DataContext = logica;
            listaDatos = new List<Datos>(); //Como rellenar un ComboBox a mano
            listaDatos.Add(new Datos("Pepito", "Pérez", new DateTime(1999, 3, 14, 17, 31, 59)));
            listaDatos.Add(new Datos("Perico", "De Los Palotes", new DateTime(2077, 5, 29)));
            foreach (Datos datos in listaDatos) { 
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content= datos;
                CB_Datos_Basico.Items.Add(cbi); //Hay que sobreescribir toString en la clase Datos
            }

            listaDatos2= new ObservableCollection<Datos>(); //importante declarar el objeto para poder usar sus métodos.
            listaDatos2.Add(new Datos("Caillou", "Fernández", new DateTime(1412, 7, 3)));
            listaDatos2.Add(new Datos("Ernesto", "Eucalipto", new DateTime(15, 2, 27)));
            CB_Binding_Basico.DataContext = this; //hay que tenerlo creado como atributo, no se puede definir la lista en el main
            I_Noice.Visibility = Visibility.Hidden;


        }

        private void CB_Datos_Basico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)CB_Datos_Basico.SelectedItem; //Como coger los valores dentro de un ComboBox. Hay que hacer el casting.
            Datos datos = (Datos) cbi.Content;
            LB_nombre.Content = datos.Nombre;
            LB_apellidos.Content = datos.Apellidos;
        }

        private void BT_Nuevo_Click(object sender, RoutedEventArgs e) //evento Click de botón
        {
            listaDatos2.Add(new Datos("Nuevo", "Nuevo", DateTime.Now)); //añadimos un elemento de ejemplo a la lista
        }

        private void BT_Modificar_Click(object sender, RoutedEventArgs e)
        {
            listaDatos2.ElementAt(0).Apellidos = "Calvote"; //modificamos un elemento de la lista
        }

        private void MI_AbrirDialog_Click(object sender, RoutedEventArgs e)
        {
            Dialog dialogo = new Dialog(logica); //creamos una instancia de la ventana
            dialogo.Show(); //mostramos la ventana
        }

        private void BT_Modificar_Click_1(object sender, RoutedEventArgs e)
        {
            if(DG_BindingLogica.SelectedIndex != -1) //comprobamos que está seleccionado un registro en la tabla
            {
                Datos datos = (Datos) DG_BindingLogica.SelectedItem; //guardamos el objeto seleccionado de la tabla
                Dialog dialogo = new Dialog(logica, (Datos) datos.Clone(), DG_BindingLogica.SelectedIndex);
                dialogo.Show();
            }
        }

        private void BT_Modificar_MouseEnter(object sender, MouseEventArgs e)
        {
            I_Noice.Visibility= Visibility.Visible;
        }

        private void BT_Modificar_MouseLeave(object sender, MouseEventArgs e)
        {
            I_Noice.Visibility = Visibility.Hidden;
        }
    }
}
