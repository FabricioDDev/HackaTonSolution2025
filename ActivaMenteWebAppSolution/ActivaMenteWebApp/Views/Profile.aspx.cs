using ActivaMenteWebApp.Entities;
using Business;
using System;
using System.Web.UI;

namespace ActivaMenteWebApp.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        Usuario user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Views/LogIn.aspx", false);
                return;
            }

            user = (Usuario)Session["Usuario"];

            if (!IsPostBack)
            {
                cargarDdlSex();
                cargarDatos(user);
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Default.aspx", false);
        }

        public void cargarDatos(Usuario user)
        {
            TxtUsername.Text = user.NombreUsuario;
            TxtEmail.Text = user.Persona.Email;
            TxtRegisterDate.Text = $"{user.FechaRegistro:yyyy-MM-dd}";
            TxtTotalPoints.Text = user.PuntosTotales.ToString();

            // Seleccionar el ítem correcto del DDL
            if (DdlSex.Items.FindByValue(user.Persona.Sexo) != null)
            {
                DdlSex.SelectedValue = user.Persona.Sexo;
            }

            TxtNationality.Text = user.Persona.Nacionalidad;
            TxtBornDate.Text = $"{user.Persona.FechaNacimiento:yyyy-MM-dd}";
        }

        public void cargarDdlSex()
        {
            DdlSex.Items.Clear();
            DdlSex.Items.Add("Masculino");
            DdlSex.Items.Add("Femenino");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioB = new UsuarioBLL();
            PersonasBLL personasBLL = new PersonasBLL();

            // Actualizar objeto usuario
            user.NombreUsuario = TxtUsername.Text.Trim();
            user.Persona.Email = TxtEmail.Text.Trim();
            user.Persona.Sexo = DdlSex.SelectedValue;
            user.Persona.Nacionalidad = TxtNationality.Text.Trim();

            if (!string.IsNullOrEmpty(TxtBornDate.Text))
            {
                user.Persona.FechaNacimiento = DateTime.Parse(TxtBornDate.Text);
            }

            bool okUsuario = usuarioB.UpdateUsuario(user);
            bool okPersona = personasBLL.UpdatePersona(user.Persona);

            if (okUsuario && okPersona)
            {
                LblWarning.Text = "Cambios guardados correctamente";
            }
            else
            {
                LblWarning.Text = "Ocurrió un error al guardar los cambios.";
            }

            // Mantener objeto actualizado en sesión
            Session["Usuario"] = user;
        }
    }
}
