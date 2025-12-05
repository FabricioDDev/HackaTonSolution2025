using ActivaMenteWebApp.Entities;
using Business;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace ActivaMenteWebApp.Views
{
    public partial class Game1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int level;
                if (!int.TryParse(Request.QueryString["lvl"], out level))
                {
                    Response.Redirect("~/Views/Games.aspx");
                    return;
                }

                Session["level"] = level;
                Session["index"] = 0;
                Session["puntaje"] = 0;
                Session["incorrectas"] = 0;

                PreguntaBLL pb = new PreguntaBLL();
                List<Pregunta> lista = pb.ObtenerPreguntas(1, level);

                if (lista == null || lista.Count == 0)
                {
                    lblPregunta.Text = "No hay preguntas disponibles.";
                    btnResponder.Enabled = false;
                    return;
                }

                Session["preguntas"] = lista;
                MostrarPregunta();
            }
        }

        private void MostrarPregunta()
        {
            if (Session["preguntas"] == null)
            {
                Response.Redirect("~/Views/Games.aspx");
                return;
            }

            List<Pregunta> preguntas = (List<Pregunta>)Session["preguntas"];
            int i = (int)Session["index"];

            if (i >= preguntas.Count)
            {
               FinalizarJuego();
                return;
            }

            Pregunta p = preguntas[i];

            lblPregunta.Text = p.Texto;
            rdbOpciones.Items.Clear();
            rdbOpciones.Items.Add(p.Opcion1);
            rdbOpciones.Items.Add(p.Opcion2);
            rdbOpciones.Items.Add(p.Opcion3);
            rdbOpciones.Items.Add(p.Opcion4);
            rdbOpciones.ClearSelection();
        }

        protected void btnResponder_Click(object sender, EventArgs e)
        {
            if (rdbOpciones.SelectedIndex == -1)
                return;

            List<Pregunta> preguntas = (List<Pregunta>)Session["preguntas"];
            int i = (int)Session["index"];
            Pregunta actual = preguntas[i];

            int elegido = rdbOpciones.SelectedIndex + 1;
            int correcta = actual.OpcionCorrecta;

            int puntaje = (int)Session["puntaje"];
            int acuIncorrecta = (int)Session["incorrectas"];
            if (elegido == correcta)
                puntaje += 10;
            else
                acuIncorrecta++;

            Session["incorrectas"] = acuIncorrecta;
            Session["puntaje"] = puntaje;
            Session["index"] = i + 1;

            MostrarPregunta();
        }

       private void FinalizarJuego()
        {
            ResultadoJuegoBLL rb = new ResultadoJuegoBLL();
            int puntaje = 0;

            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }
            puntaje = (int)Session["puntaje"];
            if ((int)Session["incorrectas"] == 0)
            {
                puntaje += 5;
            }
            ResultadoJuego resultado = new ResultadoJuego()
            {
                IdUsuario = ((Usuario)Session["Usuario"]).IdUsuario,
                IdJuego = 1,
                IdNivel = (int)Session["level"],
                PuntajeObtenido = puntaje
            };

            rb.RegistrarResultado(resultado);

            Response.Redirect($"~/Views/GameResult.aspx?puntaje={resultado.PuntajeObtenido}");
        }
    }
}
