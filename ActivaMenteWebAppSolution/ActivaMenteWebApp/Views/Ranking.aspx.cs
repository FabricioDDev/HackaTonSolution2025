using System;
using Business;   // tu namespace donde está GetRanking()

namespace ActivaMenteWebApp.Views
{
    public partial class Ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarRanking();
        }

        void CargarRanking()
        {
            UsuarioBLL negocio = new UsuarioBLL();

            var lista = negocio.getRanking();  // método corregido anteriormente

            gvRanking.DataSource = lista;
            gvRanking.DataBind();
        }
    }
}
