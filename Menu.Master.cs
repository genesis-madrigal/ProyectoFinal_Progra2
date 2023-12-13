using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Progra2
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Classes.SystemUser objsystemuser = new Classes.SystemUser();

            objsystemuser.SetLogin(Session["LogInUser"].ToString());
            objsystemuser.SetRol(int.Parse(Session["RolID"].ToString()));


            lblRol.Text = "Bienvenido " + Session["NombreRol"].ToString() + " a";
            lblUser.Text = Session["LogInUser"].ToString();
            

            if (objsystemuser.GetRol() == 3)
            {
                btnTecnicos.Visible = false;
                btnEquipos.Visible = false;
                btnAsignaciones.Visible = false;
                btnUsuarios.Visible = false;    
                btnDetallesReparaciones.Visible=false;
                btnUsuariosSystem.Visible = false;
                btnReporteRoles.Visible = false;
                btnReporteGeneral.Visible = false;

            }else if(objsystemuser.GetRol() == 2)
            {
                btnTecnicos.Visible = false;
                btnEquipos.Visible = false;                
                btnUsuarios.Visible = false;                
                btnUsuariosSystem.Visible = false;
                btnReporteRoles.Visible = false;
                btnReporteGeneral.Visible = false;
            }

        }

        

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LogIn.aspx");
        }





    }
}