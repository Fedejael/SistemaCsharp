using CURSO.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CURSO.Datos
{
    public class Dcargos
    {
        public bool Insertar_Cargo(Lcargos parametros)
        {
            try
            {
                Dconexion.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Cargo", Dconexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cargo", parametros.Cargo);
                cmd.Parameters.AddWithValue("@SueldoPorHora", parametros.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Dconexion.cerrar();
            }
        }
        public bool editar_Cargo(Lcargos parametros)
        {
            try
            {
                Dconexion.abrir();
                SqlCommand cmd = new SqlCommand("editar_Cargo", Dconexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;            
                cmd.Parameters.AddWithValue("@id", parametros.Id_cargo);
                cmd.Parameters.AddWithValue("@Cargo", parametros.Cargo);
                cmd.Parameters.AddWithValue("@Sueldo", parametros.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Dconexion.cerrar();
            }
        }
        public void buscarCargos(ref DataTable dt, string buscador)
        {
            try
            {
                Dconexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarCargos", Dconexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;        
                da.SelectCommand.Parameters.AddWithValue("@buscador", buscador);
                da.Fill(dt);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                Dconexion.cerrar();
            }
        }
    }
}
