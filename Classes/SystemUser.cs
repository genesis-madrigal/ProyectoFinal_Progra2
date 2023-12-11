using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ProyectoFinal_Progra2.Classes
{
    public class SystemUser
    {
        //atributos
        private static string LogInUser;
        private static int UsuarioID;
        private static string Clave;

        //constructor
        public SystemUser()
        {

        }

        //Getter = me devuelve un valor
        //Setter = asignar un valor a un atributo

        public int GetUsuarioID()
        {
            return UsuarioID;
        }

        public string GetLogin()
        {
            return LogInUser;
        }

        public void SetUsuarioID(int usuarioid)
        {
            UsuarioID = usuarioid;
        }

        public void SetLogin(string login)
        {
            LogInUser = login;
        }

        public void SetClave(string clave)
        {
            Clave = clave;
        }

        public static int ValidarLogin()
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("VALIDAR_USUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@loginuser", LogInUser));
                    cmd.Parameters.Add(new SqlParameter("@clave", Clave));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;

                        }
                        else
                        {
                            retorno = -1;
                        }

                    }


                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

    }
}