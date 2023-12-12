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
    public partial class Reparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDropdownEstados();
                LlenarDropdownEquipos();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Reparaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvReparaciones.DataSource = dt;
                            gvReparaciones.DataBind();
                        }
                    }
                }
            }
        }
        protected void LlenarDropdownEstados()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Consulta_Estados"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlEstado.DataSource = dt;

                            ddlEstado.DataTextField = dt.Columns["ESTADO"].ToString();
                            ddlEstado.DataValueField = dt.Columns["id"].ToString();
                            ddlEstado.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarDropdownEquipos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Consultar_Equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlEquipoID.DataSource = dt;

                            ddlEquipoID.DataTextField = dt.Columns["Equipo"].ToString();
                            ddlEquipoID.DataValueField = dt.Columns["EquipoID"].ToString();
                            ddlEquipoID.DataBind();
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
            int resultado = Reparacion.Agregar(int.Parse(ddlEquipoID.Text), char.Parse(ddlEstado.Text));

            if (resultado > 0)
            {
                alertas("Reparación ha sido ingresada con éxito");                
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar tipo");

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtReparacionID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Reparaciones WHERE ReparacionID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvReparaciones.DataSource = dt;
                        gvReparaciones.DataBind();  // actualizar el grid view
                    }
                }
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)  //SOLO DEBE PODERSE MODIFICAR EL ESTADO POR LOS TÉCNICOS
        {

            int resultado = 0;

            //Para hacer check de si son numeros o no
            bool codigo = int.TryParse(txtReparacionID.Text, out int a);

            if (codigo)
            {
                resultado = Reparacion.ModificarID(int.Parse(txtReparacionID.Text), int.Parse(ddlEquipoID.Text), char.Parse(ddlEstado.Text));
            }
            else
            {
                resultado = -2;
            }


            if (resultado > 0)
            {
                alertas("Reparación ha sido actualizado con éxito");
                txtReparacionID.Text = string.Empty;
                LlenarGrid();
            }
            else if (resultado == -2)
            {
                alertas("Error al actualizar la reparación: Ingrese un ID de la Reparación");
            }
            else
            {
                alertas("Error al actualizar la reparación");

            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int resultado = Reparacion.Borrar(int.Parse(txtReparacionID.Text));

            if (resultado > 0)
            {
                alertas("Reparación ha sido eliminada con éxito");
                txtReparacionID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar la reparación");

            }
        }
    }
}