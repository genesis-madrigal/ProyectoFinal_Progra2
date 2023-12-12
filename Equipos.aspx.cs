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
    public partial class Equipos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvEquipos.DataSource = dt;
                            gvEquipos.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }


        /*protected void Llenartipos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select id, descripcion from tipo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownList1.DataSource = dt;

                            DropDownList1.DataTextField = dt.Columns["descripcion"].ToString();
                            DropDownList1.DataValueField = dt.Columns["id"].ToString();
                            DropDownList1.DataBind();
                        }
                    }
                }
            }
        }*/

        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            int resultado = Equipo.Agregar(tbTipoEquipo.Text, tbModelo.Text, int.Parse(tbUsuarioID.Text));

            if (resultado > 0)
            {
                alertas("Equipo ha sido ingresado con éxito");
                tbEquipoID.Text = string.Empty;
                tbTipoEquipo.Text = string.Empty;
                tbModelo.Text = string.Empty;
                tbUsuarioID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar equipo");

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tbEquipoID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE EquipoID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvEquipos.DataSource = dt;
                        gvEquipos.DataBind();  // actualizar el grid view
                    }
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            int resultado = 0;

            //Para hacer check de si son numeros o no
            bool codigo = int.TryParse(tbEquipoID.Text, out int a);
            bool usuario = int.TryParse(tbUsuarioID.Text, out int b);

            if (codigo && usuario)
            {
                resultado = Equipo.ModificarID(int.Parse(tbEquipoID.Text), tbTipoEquipo.Text, tbModelo.Text, int.Parse(tbUsuarioID.Text));
            }
            else
            {
                resultado = -2;
            }


            if (resultado > 0)
            {
                alertas("Equipo ha sido actualizado con éxito");
                tbEquipoID.Text = string.Empty;
                tbTipoEquipo.Text = string.Empty;
                tbModelo.Text = string.Empty;
                tbUsuarioID.Text = string.Empty;
                LlenarGrid();
            }
            else if (resultado == -2)
            {
                alertas("Error al actualizar el equipo: Ingrese un ID del Equipo");
            }
            else
            {
                alertas("Error al actualizar el equipo");

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int resultado = Equipo.Borrar(int.Parse(tbEquipoID.Text));

            if (resultado > 0)
            {
                alertas("Equipo ha sido eliminado con éxito");
                tbEquipoID.Text = string.Empty;
                tbTipoEquipo.Text = string.Empty;
                tbModelo.Text = string.Empty;
                tbUsuarioID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar el equipo");

            }
        }
    }
}