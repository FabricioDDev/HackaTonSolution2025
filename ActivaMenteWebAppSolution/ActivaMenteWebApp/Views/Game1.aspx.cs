using ActivaMenteWebApp.Entities;
using Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;

namespace ActivaMenteWebApp.Views
{
    public partial class Game1 : Page
    {
        Usuario user;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Siempre cargar usuario
            user = (Usuario)Session["Usuario"];

            if (user == null)
            {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                int level;
                if (!int.TryParse(Request.QueryString["lvl"], out level))
                {
                    Response.Redirect("~/Views/Default.aspx");
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
                Response.Redirect("~/Views/Default.aspx");
                return;
            }

            List<Pregunta> preguntas = (List<Pregunta>)Session["preguntas"];
            int i = (int)Session["index"];
            LblQuestions.Text = "preguntas: " + (i+1) + "/" + preguntas.Count;
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
            {
                LblError.Text = "Debes seleccionar una opción.";
                return;
            }

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
            {
                LblCorrectaIncorrecta.Text = "Respuesta Correcta!!";
                puntaje += 10;
            }
            else
            {
                LblCorrectaIncorrecta.Text = "Respuesta incorrecta :c";
                acuIncorrecta++;
            }
                

            Session["incorrectas"] = acuIncorrecta;
            Session["puntaje"] = puntaje;

            // Guardar que esta pregunta ya se respondió
            Session["index"] = i + 1;

            // 1) Ocultar pregunta
            panelPregunta.Visible = false;

            // 2) Mostrar video de respuesta
            panelVideo.Visible = true;

            // 3) Cargar video desde carpeta del proyecto
            if ((int)Session["index"] == 1)
            {
                LblRespuesta.Text = "¡Es el Océano Pacífico! 🌊\r\n\r\nPara que te hagas una idea de su inmensidad:\r\n\r\nTamaño descomunal: Tiene unos 165 millones de kilómetros cuadrados.\r\n\r\nComparación: Si juntaras todos los continentes (América, Europa, África, Asia, Oceanía y la Antártida) y los metieras dentro del Pacífico, ¡todavía sobraría espacio!\r\n\r\nProfundidad: También es el hogar del lugar más profundo de la corteza terrestre: la Fosa de las Marianas";
                srcVideo.Src = ResolveUrl("~/Views/Multi/rtaP1.mp4");
            }
            else
            {
                LblRespuesta.Text = "¿Quién pintó La Mona Lisa? 🎨\r\nFue el gran genio del Renacimiento, Leonardo da Vinci (entre 1503 y 1519).\r\n\r\n\U0001f92f Pero aquí viene el \"Plot Twist\": Aunque hoy es el cuadro más famoso del mundo, durante siglos fue solo \"uno más\". Su fama mundial explotó realmente en 1911 cuando fue robada del Museo del Louvre.\r\n\r\nLo más loco de esa historia es que la policía estaba tan desesperada por encontrar al culpable que interrogaron como sospechoso a un joven pintor español... ¡Pablo Picasso! 🕵️‍♂️ (Spoiler: Picasso era inocente, el ladrón fue un empleado del museo que se la llevó escondida bajo su abrigo).\r\n\r\n🔍 Bonus Track: Si alguna vez la ves en persona, prepárate para una sorpresa: ¡Es diminuta! Mide solo 53 x 77 cm (apenas más grande que una pantalla de TV de 32 pulgadas), aunque todos se la imaginan gigante";
                srcVideo.Src = ResolveUrl("~/Views/Multi/rtaP2.mp4");
            }
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
            guardarPuntajeTotalUsuario(puntaje);

            Response.Redirect($"~/Views/GameResult.aspx?puntaje={resultado.PuntajeObtenido}");
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            panelVideo.Visible = false;
            panelPregunta.Visible = true;

            MostrarPregunta();
        }
        public void guardarPuntajeTotalUsuario(int puntaje)
        {
            user.PuntosTotales += puntaje;
            Session["Usuario"] = user;
            UsuarioBLL userB = new UsuarioBLL();
            userB.UpdatePoints(user.IdUsuario, user.PuntosTotales);
        }

    }
}
