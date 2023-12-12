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
    public partial class Tecnicos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvTecnicos.DataSource = dt;
                            gvTecnicos.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int resultado = Tecnico.Agregar(tbNombre.Text, tbEspecialidad.Text);

            if (resultado > 0)
            {
                alertas("Técnico ha sido ingresado con éxito");
                tbTecnicoID.Text = string.Empty;
                tbNombre.Text = string.Empty;
                tbEspecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar técnico");

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tbTecnicoID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos WHERE TecnicoID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvTecnicos.DataSource = dt;
                        gvTecnicos.DataBind();  // actualizar el grid view
                    }
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            int resultado = 0;

            //Para hacer check de si son numeros o no
            bool codigo = int.TryParse(tbTecnicoID.Text, out int a);

            if (codigo)
            {
                resultado = Tecnico.ModificarID(int.Parse(tbTecnicoID.Text), tbNombre.Text, tbEspecialidad.Text);
            }
            else
            {
                resultado = -2;
            }


            if (resultado > 0)
            {
                alertas("Técnico ha sido actualizado con éxito");
                tbTecnicoID.Text = string.Empty;
                tbNombre.Text = string.Empty;
                tbEspecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else if (resultado == -2)
            {
                alertas("Error al actualizar el técnico: Ingrese un ID del Técnico");
            }
            else
            {
                alertas("Error al actualizar el técnico");

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int resultado = Tecnico.Borrar(int.Parse(tbTecnicoID.Text));

            if (resultado > 0)
            {
                alertas("Técnico ha sido eliminado con éxito");
                tbTecnicoID.Text = string.Empty;
                tbNombre.Text = string.Empty;
                tbEspecialidad.Text = string.Empty;

                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar el técnico");

            }
        }
    }
}