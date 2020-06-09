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
    }
}
