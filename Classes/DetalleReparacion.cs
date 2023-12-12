using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoFinal_Progra2.Classes
{
    public class DetalleReparacion
    {
            public int DetalleID { get; set; }

            public int ReparacionID { get; set; }

            public string Descripcion { get; set; }

            public string FechaInicio { get; set; }

            public string FechaFin { get; set; }


        public DetalleReparacion(int detalleid, int reparacionid, string descripcion, string fechai, string fechafin)
            {
                DetalleID = detalleid;
                ReparacionID = reparacionid;
                Descripcion = descripcion;
                FechaInicio = fechai;
                FechaFin = fechafin;
        }


            public static int Agregar(string reparacionid, string descripcion, string fechafin)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBConn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("INSERTAR_DETALLESREPARACION", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionid));
                        cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));
                        cmd.Parameters.Add(new SqlParameter("@FECHAFIN", fechafin));


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
                        SqlCommand cmd = new SqlCommand("BORRAR_DETALLESREPARACION", Conn)
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
                        using (SqlCommand cmd = new SqlCommand("CONSULTAR_DetallesReparacion_ID", Conn)
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
            public static int ModificarID(int detalleid, int reparacionid, string descripcion, string fechafin)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBConn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("ACTUALIZAR_DETALLESREPARACION", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@CODIGO", detalleid));
                        cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionid));
                        cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));
                        cmd.Parameters.Add(new SqlParameter("@FECHAFIN", fechafin));

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
