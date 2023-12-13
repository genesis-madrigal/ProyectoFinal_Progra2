using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinal_Progra2.Classes;

namespace ProyectoFinal_Progra2
{
    public partial class DetallesReparacion : System.Web.UI.Page
    {

        private static Classes.SystemUser objsystemuser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objsystemuser = new Classes.SystemUser();

                objsystemuser.SetLogin(Session["LogInUser"].ToString());
                objsystemuser.SetRol(int.Parse(Session["RolID"].ToString()));

                LlenarGrid();

                LlenarDropdown();

            }
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CONSULTAR_DetallesReparacion @LOGIN =" + objsystemuser.GetLogin() + ", @ROLID = " + objsystemuser.GetRol()))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvDetalles.DataSource = dt;
                            gvDetalles.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarDropdown()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CONSULTAR_REPARACIONES @LOGIN =" + objsystemuser.GetLogin() + ", @ROLID = " + objsystemuser.GetRol()))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlReparaciones.DataSource = dt;

                            ddlReparaciones.DataTextField = dt.Columns["ReparacionID"].ToString();
                            ddlReparaciones.DataBind();
                        }
                    }
                }
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


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int resultado = DetalleReparacion.Agregar(ddlReparaciones.Text, txtDescripcion.Text, txtFechaFin.Text);
            
            if (resultado > 0)
            {
                alertas("Detalle de reparación ha sido ingresado con éxito");
                txtDetalleID.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtFechaFin.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar detalle de reparación");

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            bool check = int.TryParse(txtDetalleID.Text, out int a);

            if (check)
            {
                int codigo = int.Parse(txtDetalleID.Text);
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_DetallesReparacion_ID @CODIGO =" + codigo + ",@LOGIN =" + objsystemuser.GetLogin() + ", @ROLID = " + objsystemuser.GetRol()))


                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvDetalles.DataSource = dt;
                            gvDetalles.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
            else
            {
                LlenarGrid();
            }
        }

        //AYUDA

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            int resultado = 0;

            //Para hacer check de si son numeros o no
            bool codigo = int.TryParse(txtDetalleID.Text, out int a);

            if (codigo)
            {
                resultado = DetalleReparacion.ModificarID(int.Parse(txtDetalleID.Text), int.Parse(ddlReparaciones.Text), txtDescripcion.Text, txtFechaFin.Text);
            }
            else
            {
                resultado = -2;
            }


            if (resultado > 0)
            {
                alertas("Detalle de reparación ha sido actualizado con éxito");
                txtDetalleID.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtFechaFin.Text = string.Empty;
                LlenarGrid();
            }
            else if (resultado == -2)
            {
                alertas("Error al actualizar detalle de reparación: Ingrese un ID del detalle");
            }
            else
            {
                alertas("Error al actualizar el detalle de reparación");

            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int resultado = DetalleReparacion.Borrar(int.Parse(txtDetalleID.Text));

            if (resultado > 0)
            {
                alertas("Detalle de reparación ha sido eliminado con éxito");
                txtDetalleID.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtFechaFin.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar el detalle de reparación");

            }
        }
    }
}