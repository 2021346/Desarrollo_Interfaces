using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace EjemploAppWPF.CarpetaDatos
{
    public class Datos : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged; //creamos el evento para avisar de los cambios de valor
        private String nombre;
        public String Nombre { 
            get{ 
                return nombre; 
            } 
            set {
                this.nombre = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nombre")); //Aviso de que ha cambiado el valor
            }
        }
        private String apellidos;



        public String Apellidos { 
            get {
                return apellidos;
            } 
            set {
                this.apellidos = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Apellidos")); //Aviso de que ha cambiado el valor
            }
        }

        private DateTime cumple;
        public DateTime Cumple { 
            get {
                return cumple;
            } 
            set {
                this.cumple = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Cumple")); //Aviso de que ha cambiado el valor
            } 
        }

        public Datos() { 
            this.cumple= DateTime.Now; //damos la fecha actual por defecto
        }
        public Datos(string nombre, string apellidos, DateTime cumple)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.cumple = cumple;
        }

        public override string ToString()
        {
            return nombre + " " + apellidos;
        }

        public object Clone()
        {
            return this.MemberwiseClone(); //devolvemos el objeto clonado
        }
        public string Error => "";

        public string this[string columnName] {
            get {
                String resultado = "";
                if (columnName == "Nombre") { //comprobamos el nombre
                    if (string.IsNullOrEmpty(Nombre)) //comprobamos si hay datos
                    {
                        resultado = "Debe introducir el Nombre";
                    }
                    
                }
                if(columnName == "Apellidos") //comprobamos el apellido
                {
                    if (string.IsNullOrEmpty(Apellidos)) //comprobamos si hay dato
                    {
                        resultado = "Debe introducir el apellido";
                    }
                }
                return resultado; //devolvemos el error
            }
        }
    }
}
