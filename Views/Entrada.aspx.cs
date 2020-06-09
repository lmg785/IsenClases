using IsenClases.Controllers;
using IsenClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsenClases.Views
{
    public partial class Entrada : System.Web.UI.Page
    {
        HomeController controller = new HomeController();
        public List<Clases> clases { get; set; }
        public IUsuario usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (IUsuario)Session["Usuario"];

            if (usuario == null) Response.Redirect("Error.aspx");

            controller.GetAsignaturas(usuario);
            clases = controller.GetClases(usuario);
        }

        
    }
}