﻿using ProyectoFinal_Progra2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Progra2
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Classes.SystemUser objsystemuser = new Classes.SystemUser();

            objsystemuser.SetLogin(txtUsuario.Text);
            objsystemuser.SetClave(txtClave.Text);
                      
            
            if (SystemUser.ValidarLogin() > 0)
            {                
                Session["LogInUser"] = objsystemuser.GetLogin();
                Session["RolID"] = objsystemuser.GetRol();
                Session["NombreRol"] = objsystemuser.GetNombreRol();
                Response.Redirect("Home.aspx");
            }

            



        }


    }
}