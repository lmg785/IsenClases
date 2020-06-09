using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsenClases.Model
{
    public class Profesor : IUsuario
    {
        private int _idProfesor;
        private string _dni;
        private string _nombre;
        private string _apellidos;
        private string _password;
        private List<Asignatura> _asignaturas = new List<Asignatura>();

        public int IdUsuario
        {
            get
            {
                return _idProfesor;
            }

            set
            {
                _idProfesor = value;
            }
        }
        public string Dni
        {
            get
            { return _dni; }

            set
            { _dni = value; }
        }

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Rol { get { return "P"; } }

        public List<Asignatura> ListaAsignaturas { get { return _asignaturas;  } set { _asignaturas = value; } }

        public Profesor() { }
        public Profesor(PROFESORES profesor) 
        {
            _idProfesor = profesor.ID;
            _dni = profesor.DNI;
            _nombre = profesor.NOMBRE;
            _apellidos = profesor.APELLIDOS;
            _password = profesor.PASSWORD;
        }

    }
}