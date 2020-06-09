using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsenClases.Model
{
    public class Clases
    {
        private int _idClase;
        private Asignatura _asignatura;
        private DateTime _fechaCompleta;
        private List<Alumno> _alumnos;

        public Clases() { }
        public Clases(CLASES clase) 
        {
            _idClase = clase.ID;
            _asignatura = new Asignatura();
            _asignatura.IdAsignatura = clase.ID_ASIGNATURA;
            TimeSpan ts = clase.HORA.Value;
            FechaCompleta = clase.FECHA + ts;
        } 

        public int IdClase { get { return _idClase; } set { _idClase = value; } }

        public Asignatura Asignatura { get { return _asignatura; } set { _asignatura = value; } }

        public string Fecha { get { return _fechaCompleta.Date.ToString("dd/MM/yyyy"); } }

        public string Hora { get { return _fechaCompleta.ToString("HH:mm"); } }

        public DateTime FechaCompleta { get { return _fechaCompleta; } set { _fechaCompleta = value; } }

        public List<Alumno> ListaAlumnos { get { return _alumnos; } set { _alumnos = value; } }
    }
}