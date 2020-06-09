using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsenClases.Model
{
    public class Registro
    {
        private Alumno _alumno;
        private Clases _clase;
        private bool _asiste;
        
        public Alumno AlumnoObj { get { return _alumno; } set { _alumno = value; } }
        public Clases ClaseObj { get { return _clase; } set { _clase = value; } }
        public bool Asistencia { get { return _asiste; } set { _asiste = value; } }

    }
}