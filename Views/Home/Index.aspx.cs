using IsenClases.Controllers;
using System;
using System.Web.UI;

namespace IsenClases.Views
{
    public partial class Index : System.Web.Mvc.ViewPage
    {
        HomeController controller = new HomeController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string username = Request["Username"];
                string password = Request["Password"];

                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    return;
                
                bool login = controller.Login(username, password);
                if(login)
                    Response.Redirect("/Home/Entrar");
                else
                    Response.Redirect("Error.aspx");
            }
            controller.InitDb();
        }

    }
}