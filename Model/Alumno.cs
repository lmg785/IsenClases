using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IsenClases.Model
{
    public class Alumno : IUsuario
    {
        private int _idAlumno;
        private string _dni;
        private string _nombre;
        private string _apellidos;
        private string _password;
        private List<Asignatura> _asignaturas = new List<Asignatura>();
        private List<Registro> _clasesApuntadas = new List<Registro>();

        public int IdUsuario
        {
            get { return _idAlumno; }
            set { _idAlumno = value; }
        }
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Rol { get { return "E"; } }

        public List<Asignatura> ListaAsignaturas { get { return _asignaturas; } set { _asignaturas = value; }  }

        public List<Registro> ClasesApuntadas { get { return _clasesApuntadas; } set { _clasesApuntadas = value; } }

        public Alumno() { }
        public Alumno(ALUMNOS a) 
        {
            _idAlumno = a.ID;
            _nombre = a.NOMBRE;
            _apellidos = a.APELLIDOS;
            _password = a.PASSWORD;
        }

        private void Apuntarse(Clases clase) 
        {
            Registro r = new Registro()
            {
                AlumnoObj = this,
                ClaseObj = clase,
                Asistencia = true
            };

            _clasesApuntadas.Add(r);
        }

        public void Asistencia(Clases clase) 
        {
            int index = _clasesApuntadas.FindIndex(f => f.ClaseObj.IdClase.Equals(clase.IdClase));
            if (index >= 0)
            {
                _clasesApuntadas[index].Asistencia = !_clasesApuntadas[index].Asistencia;
            }
            else 
            {
                Apuntarse(clase);
            }
        }

        public bool isUsuarioRegistrado(Clases cls) 
        {
            int index = ClasesApuntadas.FindIndex(f => f.ClaseObj.IdClase.Equals(cls.IdClase));
            return index > 0;
        }

    }
}