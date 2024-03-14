using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo4
{
    internal class Empleado
    {
        //atributos
        private int carnet;
        private string nombre;
        private int edad;
        //propiedades con validación
        public int Carnet
        {
            get { return carnet; }
            set
            {
                carnet = value;
                if (carnet <= 0)
                    throw new Exception("Dato incorrecto para carnet");
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                if (nombre == "")
                    throw new Exception("No debe dejar en blanco el nombre");
                foreach (char letra in nombre)
                {
                    //caracteres permitidos
                    switch (letra)
                    {
                        case 'Á': continue;
                        case 'É': continue;
                        case 'Í': continue;
                        case 'Ó': continue;
                        case 'Ú': continue;
                    }
                    if (letra < 'A' || letra > 'Z')
                    {
                        throw new Exception("Solamente se permiten mayúsculas en el nombre");
                    }
                }
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                edad = value;
                if (edad < 0 || edad > 110)
                    throw new Exception("Dato fuera del rango");
            }
        }
    }
}