using IsenClases.Controllers;
using IsenClases.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IsenClases.Views
{
    public partial class Entrada : ViewPage
    {
        HomeController controller = new HomeController();
        public List<Clases> clases { get; set; }
        public IUsuario usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (IUsuario)Session["Usuario"];

            if (usuario == null) Response.Redirect("/Home/Error");

            controller.GetAsignaturas(usuario);
            clases = controller.GetClases(usuario);
        }

        
    }
}