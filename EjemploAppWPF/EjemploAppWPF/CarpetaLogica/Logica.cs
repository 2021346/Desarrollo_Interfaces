using EjemploAppWPF.CarpetaDatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EjemploAppWPF.CarpetaLogica
{
    public class Logica
    {
        public ObservableCollection<Datos> listaDatosLogica { get; set; }

        public Logica() {
            listaDatosLogica = new ObservableCollection<Datos>();
            listaDatosLogica.Add(new Datos("NombreEjemplo", "ApellidoEjemplo", new DateTime(1, 1, 1)));
        }
        public void aniadir (Datos datos)
        {
            listaDatosLogica.Add(datos);
        }

        public void modificar (Datos datos, int posicion)
        {
            listaDatosLogica[posicion] = datos;
        }
    }
}
