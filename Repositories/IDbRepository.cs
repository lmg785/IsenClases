using IsenClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsenClases.Repositories
{
    interface IDbRepository
    {
        void Inicializar();
        IEnumerable<IUsuario> GetUsuarios();
        IUsuario GetUsuario(string dni);
        List<Clases> GetClases(IUsuario usuario);
        void GetAsignaturas(IUsuario usuario);
        bool IsProfesorAsignatura(int idClase, int idUsuario);
        int ModificarClase(int idClase, DateTime fechaClase, TimeSpan horaClase);
        bool IsAlumnoAsignatura(int idClase, int idUsuario);
        void ModificarAsistencia(int idClase, int idUsuario, bool asiste);
    }
}
