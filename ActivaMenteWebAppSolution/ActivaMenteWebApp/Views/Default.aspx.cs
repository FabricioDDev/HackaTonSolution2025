using ActivaMenteWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivaMenteWebApp.Views
{
    public partial class Default : System.Web.UI.Page
    {
        string userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Views/LogIn.aspx", false);
            }
            else
            {
                Usuario user = new Usuario();
                user = (Usuario)Session["Usuario"];
                LblUserName.Text = user.NombreUsuario;
            }
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Views/LogIn.aspx", false);
        }

        protected void BtnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile.aspx", false);
        }
    }
}