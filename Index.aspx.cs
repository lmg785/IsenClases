using IsenClases.Controllers;
using System;
using System.Web.UI;

namespace IsenClases.Views
{
    public partial class Index : System.Web.UI.Page
    {
        HomeController controller = new HomeController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) 
            {
                string username = Request["Username"];
                string password = Request["Password"];

                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    return;
                
                bool login = controller.Login(username, password, this.Session);

                if (login) 
                {
                    Response.Redirect("Views/Entrada.aspx");
                }
                Response.Redirect("Views/Error.aspx");

            }
            else
                controller.InitDb();
        }
    }
}