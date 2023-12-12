using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Progra2
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                //Llenartipos();
            }

        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvUsuarios.DataSource = dt;
                            gvUsuarios.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int resultado = Usuario.Agregar(tbNombre.Text, tbCorreo.Text, tbTelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario ha sido ingresado con éxito");
                tbUsuarioID.Text = string.Empty;
                tbNombre.Text = string.Empty;
                tbCorreo.Text = string.Empty;
                tbTelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar usuario");

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tbUsuarioID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UsuarioID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvUsuarios.DataSource = dt;
                        gvUsuarios.DataBind();  // actualizar el grid view
                    }
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            int resultado = 0;

            //Para hacer check de si son numeros o no
            bool codigo = int.TryParse(tbUsuarioID.Text, out int a);
            bool usuario = int.TryParse(tbUsuarioID.Text, out int b);

            if (codigo && usuario)
            {
                resultado = Usuario.ModificarID(int.Parse(tbUsuarioID.Text), tbNombre.Text, tbCorreo.Text, tbTelefono.Text);
            }
            else
            {
                resultado = -2;
            }


            if (resultado > 0)
            {
                alertas("Usuario ha sido actualizado con éxito");
                tbUsuarioID.Text = string.Empty;
                tbNombre.Text = string.Empty;
                tbCorreo.Text = string.Empty;
                tbTelefono.Text = string.Empty;
                LlenarGrid();
            }
            else if (resultado == -2)
            {
                alertas("Error al actualizar el usuario: Ingrese un ID del Usuario");
            }
            else
            {
                alertas("Error al actualizar el usuario");

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int resultado = Usuario.Borrar(int.Parse(tbUsuarioID.Text));

            if (resultado > 0)
            {
                alertas("Usuario ha sido eliminado con éxito");
                tbUsuarioID.Text = string.Empty;
                tbNombre.Text = string.Empty;
                tbCorreo.Text = string.Empty;
                tbTelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar el usuario");

            }
        }
    }
}