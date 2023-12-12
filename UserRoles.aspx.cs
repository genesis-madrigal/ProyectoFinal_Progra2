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
    public partial class UserRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDropdownSystemUsers();
                LlenarDropdownRoles();

            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM UserRoles"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvUserRoles.DataSource = dt;
                            gvUserRoles.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarDropdownSystemUsers()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM SystemUsers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlLogin.DataSource = dt;
                            ddlLogin.DataTextField = dt.Columns["LogInUser"].ToString();
                            ddlLogin.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarDropdownRoles()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CONSULTA_ROLES"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddlRolID.DataSource = dt;

                            ddlRolID.DataTextField = dt.Columns["Rol"].ToString();
                            ddlRolID.DataValueField = dt.Columns["RolID"].ToString();
                            ddlRolID.DataBind();
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
            int resultado = Classes.UserRoles.Agregar(ddlLogin.Text, int.Parse(ddlRolID.Text));

            if (resultado > 0)
            {
                alertas("Rol agregado al System User con éxito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar");

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string codigo = ddlLogin.Text;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM UserRoles WHERE LogInUser ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvUserRoles.DataSource = dt;
                        gvUserRoles.DataBind();  // actualizar el grid view
                    }
                }
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)  //SOLO DEBE PODERSE MODIFICAR EL ESTADO POR LOS TÉCNICOS
        {

            int resultado = 0;

            //Para hacer check de si son numeros o no         

            
            resultado = Classes.UserRoles.ModificarID(ddlLogin.Text, int.Parse(ddlRolID.Text));
            


            if (resultado > 0)
            {
                alertas("Rol ha sido asignado con éxito");                
                LlenarGrid();
            }
            else if (resultado == -2)
            {
                alertas("Error al actualizar el rol");
            }
            else
            {
                alertas("Error al actualizar el rol");

            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int resultado = Classes.UserRoles.Borrar(ddlLogin.Text);

            if (resultado > 0)
            {
                alertas("Asignación de rol al system user ha sido eliminada con éxito");                
                LlenarGrid();
            }
            else
            {
                alertas("Error al eliminar el rol del system user");

            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

    }
}