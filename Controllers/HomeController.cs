using IsenClases.Model;
using IsenClases.Repositories;
using System;
using System.Collections.Generic;
using System.Web.SessionState;


namespace IsenClases.Controllers
{
    class HomeController
    {
        private IDbRepository _db;

        private IDbRepository db 
        { 
            get 
            { 
                if (_db == null) 
                    _db = new SqlServerRepository(); 
                return _db; 
            } 
        }

        public void InitDb() 
        {
            db.Inicializar();
        }

        public Boolean Login(string username, string password, HttpSessionState session) 
        {
            IsenClases.Model.IUsuario usuario = null;
            
            usuario = db.GetUsuario(username);

            if (usuario != null && password.Equals(usuario.Password))
            {
                session.Add("Usuario", usuario);
                return true;
            }

            return false;
        }

        public List<Clases> GetClases(IUsuario usuario) 
        {
            List<Clases> clases = new List<Clases>();

            clases = db.GetClases(usuario);

            return clases;
        }

        public void GetAsignaturas(IUsuario usuario) 
        {
            db.GetAsignaturas(usuario);
        }

    }
}