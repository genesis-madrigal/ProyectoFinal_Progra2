using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Progra2.Classes
{
    public class Reparacion
    {

        public int ReparacionID { get; set; }

        public int EquipoID { get; set; }

        public string FechaReparacion { get; set; }

        public char Estado { get; set; }


        public Reparacion(int reparacionid, int equipoID, string fecha, char estado)
        {
            ReparacionID = reparacionid;
            EquipoID = equipoID;
            FechaReparacion = fecha;
            Estado = estado;
        }


        public static int Agregar(int equipoID, char estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_REPARACIONES", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));


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
                    SqlCommand cmd = new SqlCommand("BORRAR_REPARACIONES", Conn)
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
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_REPARACIONES_ID", Conn)
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
        public static int ModificarID(int reparacionid, int equipoid, char estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_REPARACIONES", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", reparacionid));
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", equipoid));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));

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