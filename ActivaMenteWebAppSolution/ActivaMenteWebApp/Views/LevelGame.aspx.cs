using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ActivaMenteWebApp.Views
{
    public partial class LevelGame : System.Web.UI.Page
    {
        int gameId;
        protected void Page_Load(object sender, EventArgs e)
        {
            string gameParam = Request.QueryString["game"];
            gameId = int.Parse(gameParam);
        }

        protected void BtnLvl1_Click(object sender, EventArgs e)
        {
            if (gameId == 1)
            {
                Response.Redirect($"~/Views/Game1.aspx?lvl=1", false);
            }
            else if (gameId == 2) {
                Response.Redirect($"~/Views/Game2.aspx?lvl=1", false);
            }
            else
            {
                Response.Redirect($"~/Views/Default.aspx", false);
            }
        }
    }
}