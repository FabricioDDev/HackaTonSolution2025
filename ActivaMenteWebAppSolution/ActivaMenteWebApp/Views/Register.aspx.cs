using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using DB;

namespace ActivaMenteWebApp.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text == "" || TxtApellido.Text == "" || TxtEmail.Text == "" ||
                TxtUsuario.Text == "" || TxtPass.Text == "" || TxtPass2.Text == "")
            {
                LblMensaje.Text = "Por favor completa todos los campos obligatorios.";
                return;
            }

            if (TxtPass.Text != TxtPass2.Text)
            {
                LblMensaje.Text = "Las contraseñas no coinciden.";
                return;
            }

            if (EmailExiste(TxtEmail.Text))
            {
                LblMensaje.Text = "El email ya está registrado.";
                return;
            }

            if (UsuarioExiste(TxtUsuario.Text))
            {
                LblMensaje.Text = "El nombre de usuario ya existe.";
                return;
            }

            int idPersona = InsertarPersona();
            if (idPersona <= 0)
            {
                LblMensaje.Text = "Error al registrar la persona.";
                return;
            }

            if (!InsertarUsuario(idPersona))
            {
                LblMensaje.Text = "Error al registrar el usuario.";
                return;
            }

            LblMensaje.CssClass = "text-success";
            LblMensaje.Text = "Registro exitoso.";

            Response.Redirect("LogIn.aspx");
        }

        public bool EmailExiste(string email)
        {
            DataAccess db = new DataAccess();

            try
            {
                db.Query("SELECT COUNT(*) FROM Personas WHERE email = @email");
                db.Parameters("@email", email);

                db.Read();
                db.Reader.Read();

                int cantidad = db.Reader.GetInt32(0);

                if (cantidad > 0)
                    return true;

                return false;
            }
            finally
            {
                db.Close();
            }
        }

        private bool UsuarioExiste(string usuario)
        {
            DataAccess db = new DataAccess();

            try
            {
                db.Query("SELECT COUNT(*) FROM Usuario WHERE nombre_usuario = @usuario");
                db.Parameters("@usuario", usuario);

                db.Read();
                db.Reader.Read();

                return db.Reader.GetInt32(0) > 0;
            }
            finally
            {
                db.Close();
            }
        }

        private int InsertarPersona()
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query(@"
                    INSERT INTO Personas (nombre, apellido, sexo, nacionalidad, fecha_nacimiento, email)
                    OUTPUT INSERTED.idPersona
                    VALUES (@nombre, @apellido, @sexo, @nacionalidad, @fecha, @mail)");

                db.Parameters("@nombre", TxtNombre.Text);
                db.Parameters("@apellido", TxtApellido.Text);
                db.Parameters("@sexo", DdlSexo.SelectedValue);
                db.Parameters("@nacionalidad", TxtNacionalidad.Text);

                if (TxtFechaNacimiento.Text == "")
                    db.Parameters("@fecha", DBNull.Value);
                else
                    db.Parameters("@fecha", TxtFechaNacimiento.Text);

                db.Parameters("@mail", TxtEmail.Text);

                db.Read();

                int id = 0;
                if (db.Reader.Read())
                    id = Convert.ToInt32(db.Reader[0]);

                return id;
            }
            finally
            {
                db.Close();
            }
        }

        private bool InsertarUsuario(int idPersona)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query(@"
                    INSERT INTO Usuario (idPersona, nombre_usuario, contrasenia, avatar)
                    VALUES (@idPersona, @usuario, @pass, @avatar)");

                db.Parameters("@idPersona", idPersona);
                db.Parameters("@usuario", TxtUsuario.Text);
                db.Parameters("@pass", TxtPass.Text);

                if (TxtAvatar.Text == "")
                    db.Parameters("@avatar", DBNull.Value);
                else
                    db.Parameters("@avatar", TxtAvatar.Text);

                db.Execute();

                return true;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
