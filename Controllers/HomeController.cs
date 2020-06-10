using IsenClases.Model;
using IsenClases.Repositories;
using IsenClases.Utils;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace IsenClases.Controllers
{

    public class HomeController : Controller
    {
        private IDbRepository _db;
        private IUsuario _usuario;
        
        public IUsuario Usuario 
        {
            get 
            {
                if (_usuario == null) _usuario = (IUsuario)System.Web.HttpContext.Current.Session["Usuario"];
                return _usuario;
            }
            set { _usuario = value; }
        }

        private IDbRepository db 
        { 
            get 
            { 
                if (_db == null) 
                    _db = new SqlServerRepository(); 
                return _db; 
            } 
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public void InitDb() 
        {
            db.Inicializar();
            Log.Instance.WriteLog("Información inicializada");
        }

        public Boolean Login(string username, string password) 
        {
            Usuario = db.GetUsuario(username);

            if (Usuario != null && password.Equals(Usuario.Password))
            {
                System.Web.HttpContext.Current.Session.Add("Usuario", Usuario);
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

        [HttpPost]
        public ActionResult Actualizar(FormCollection formCollection)
        {
            if (Usuario != null)
            {
                if (Int32.TryParse(formCollection["IdClase"], out int idClase))
                {
                    if (Usuario.IsProfesor && IsProfesorAsignatura(idClase, Usuario.IdUsuario))
                    {
                        string fechaClase = formCollection["fechaClase"];
                        string horaClase = formCollection["horaClase"];
                        if (DateTime.TryParse(fechaClase, out DateTime fClase) && TimeSpan.TryParse(horaClase, out TimeSpan hClase))
                            db.ModificarClase(idClase, fClase, hClase);
                    }
                    else if (IsAlumnoAsignatura(idClase, Usuario.IdUsuario)) 
                    {
                        string asisteStr = formCollection["asiste"];
                        if (Boolean.TryParse(asisteStr, out bool asiste)) 
                        {
                            db.ModificarAsistencia(idClase, Usuario.IdUsuario, asiste);
                        }
                    }

                    return View("Entrada");
                }
            }
            return View("Error");
        }

        private bool IsAlumnoAsignatura(int idClase, int idUsuario)
        {
            return db.IsAlumnoAsignatura(idClase, idUsuario);
        }

        private bool IsProfesorAsignatura(int idClase, int idUsuario)
        {
            return db.IsProfesorAsignatura(idClase, idUsuario);
        }

        public ActionResult Entrar() 
        {
            if (Usuario != null)
                return View("Entrada");
            else
                return View("Error");
        }

    }
}