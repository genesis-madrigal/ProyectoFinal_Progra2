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
    public partial class Asignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();

                LlenarDropdownTecnico();

                LlenarDropdownReparacion();

            }
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Asignaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvAsignaciones.DataSource = dt;
                            gvAsignaciones.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarDropdownTecnico()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CONSULTAR_TECNICOS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlTecnicos.DataSource = dt;

                            ddlTecnicos.DataTextField = dt.Columns["Tecnico"].ToString();
                            ddlTecnicos.DataValueField = dt.Columns["TecnicoID"].ToString();
                            ddlTecnicos.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarDropdownReparacion()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CONSULTAR_REPARACIONES"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlReparacion.DataSource = dt;

                            ddlReparacion.DataTextField = dt.Columns["ReparacionID"].ToString();
                            ddlReparacion.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarEdit()
        {
            btnAgregar.Enabled = false;
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
            int resultado = Asignacion.Agregar(ddlReparacion.Text, int.Parse(ddlTecnicos.Text));

            if (resultado > 0)
            {
                alertas("Asignación ha sido ingresada con éxito");
                txtAsignacionID.Text = string.Empty;                
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar asignación");

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtAsignacionID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Asignaciones WHERE AsignacionID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvAsignaciones.DataSource = dt;
                        gvAsignaciones.DataBind();  // actualizar el grid view
                    }
                }
            }
        }

       
        protected void btnModificar_Click(object sender, EventArgs e)
        {

          int resultado = 0;

          //Para hacer check de si son numeros o no
          bool codigo = int.TryParse(txtAsignacionID.Text, out int a);

          if (codigo)
          {
              resultado = Asignacion.ModificarID(int.Parse(txtAsignacionID.Text), int.Parse(ddlReparacion.Text), int.Parse(ddlTecnicos.Text));
          }
          else
          {
              resultado = -2;
          }


          if (resultado > 0)
          {
              alertas("Asignación ha sido actualizada con éxito");
              txtAsignacionID.Text = string.Empty;              
              LlenarGrid();
          }
          else if (resultado == -2)
          {
              alertas("Error al actualizar la asignación: Ingrese un ID de la Asignación");
          }
          else
          {
              alertas("Error al actualizar la asignación");

          }
        }

        
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
          int resultado = Asignacion.Borrar(int.Parse(txtAsignacionID.Text));

          if (resultado > 0)
          {
              alertas("Asignación ha sido eliminada con éxito");
              txtAsignacionID.Text = string.Empty;
              LlenarGrid();
          }
          else
          {
              alertas("Error al eliminar la asignación");

          }
        }
    }
}