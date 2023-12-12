using ProyectoFinal_Progra2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Progra2.Classes
{
    public class Asignacion
    {
        public int AsignacionID { get; set; }

        public int ReparacionID { get; set; }

        public int TecnicoID { get; set; }

        public string FechaAsignacion { get; set; }


        public Asignacion(int asignacionid, int reparacionid, int tecnicoid, string fecha)
        {
            AsignacionID = asignacionid;
            ReparacionID = reparacionid;
            TecnicoID = tecnicoid;
            FechaAsignacion = fecha;
        }


        public static int Agregar(string reparacionid, int tecnicoid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_ASIGNACIONES", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionid));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecnicoid));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }


        public static int Borrar(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_ASIGNACIONES", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", id));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int ConsultarID(int id, GridView gv)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_ASIGNACIONES_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@CODIGO", id));
                        using (SqlDataAdapter SDA = new SqlDataAdapter())
                        {
                            SDA.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                SDA.Fill(dt);
                                gv.DataSource = dt;
                                gv.DataBind();

                                retorno = cmd.ExecuteNonQuery();
                            }
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
            }

            return retorno;
        }
        public static int ModificarID(int asignacionid, int reparacionid, int tecnicoid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_ASIGNACIONES", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", asignacionid));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionid));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecnicoid));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}



