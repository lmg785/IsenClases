using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsenClases.Model
{
    public class Asignatura
    {
        private int _idAsignatura;
        private string _titulo;
        private string _descripcion;
        private Profesor _profesor;

        public Asignatura() { }
        public Asignatura(ASIGNATURAS asignatura) 
        {
            _idAsignatura = asignatura.ID;
            _titulo = asignatura.TITULO;
            _descripcion = asignatura.DESCRIPCION;
            if (asignatura.ID_PROFESOR.HasValue)
                _profesor = new Profesor() { IdUsuario = asignatura.ID_PROFESOR.Value };
        }

        public int IdAsignatura { get { return _idAsignatura; } set { _idAsignatura = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public Profesor Profesor { get { return _profesor; } set { _profesor = value; } }

    }
}