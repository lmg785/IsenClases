

using System.Collections.Generic;

namespace IsenClases.Model
{
    public interface IUsuario
    {
        int IdUsuario { get; set; }

        string Dni { get; set; }

        string Nombre { get; set; }

        string Apellidos { get; set; }

        string Password { get; set; }

        string Rol { get; }

        List<Asignatura> ListaAsignaturas { get; set; }
    }
}
