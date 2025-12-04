using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using ActivaMenteWebApp.Entities;

namespace ActivaMenteWebApp.Views
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioB = new UsuarioBLL();
            Usuario usuario = new Usuario();
            if(usuarioB.Login(TxtUserName.Text, TxtPass.Text, ref usuario))
            {
                Session["Usuario"] = usuario;

                // Redireccionar a Default.aspx
                Response.Redirect("~/Views/Default.aspx", false);
            }
            else
            {
                LblWarning.Text = "Usuario no encontrado. Por favor, intente nuevamente.";
            }
        }
    }
}