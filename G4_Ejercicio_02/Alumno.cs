using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4_Ejercicio_02
{
    public class Alumno
    {   // Atributos
        private string nombres;
        private string apellidos;
        private string carnet;
        private string fechaNacimiento;
        private string correo;
        private string responsable;
        private string materiaInscrita;

        // Propiedades
        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Carnet
        {
            get { return carnet; }
            set { carnet = value; }
        }

        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }

        public string MateriaInscrita
        {
            get { return materiaInscrita; }
            set { materiaInscrita = value; }
        }
    }
}