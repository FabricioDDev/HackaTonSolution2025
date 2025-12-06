using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivaMenteWebApp.Views
{
    public partial class GameResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int puntaje;

                // Si falta el puntaje → volver
                if (!int.TryParse(Request.QueryString["puntaje"], out puntaje))
                {
                    Response.Redirect("~/Views/Default.aspx");
                    return;
                }

                lblMensaje.Text = $"Puntaje obtenido: {puntaje}";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Ranking.aspx");
        }
    }
}