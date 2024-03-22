using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace examen1ds31_RH.Models
{
    public class DAOUsuario
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAOUsuario()
        {
            // ----------------------------Sourse ----------------------------------------------------------------------
            this.con.ConnectionString = @"Data Source = MAKIMA\SQLEXPRESSR; initial catalog=examen1ds31; integrated security=true";
            //----------------------------------------------------------------------------------------------------------

        }
        //-------------------login
        public string login(string nombre_usuario, string contra)
        {
            string nivel_usuario = "";
            this.cmd.CommandText = "select nivel_usuario from usuarios where nombre_usuario ='"
                + nombre_usuario + "' and contra='"
                + contra + "'";
            this.cmd.Connection = this.con;
            this.cmd.Connection.Open();
            SqlDataReader lector = this.cmd.ExecuteReader();

            while (lector.Read())
            {
                nivel_usuario = lector[0].ToString();
            }
            return nivel_usuario;
        }
        //--------------------------------------------------


        public List<Usuarios> GetTabla()
        {
            List<Usuarios> data = new List<Usuarios>();
            cmd.Connection = con;
            cmd.CommandText = "select * from usuarios";
            cmd.Connection.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                data.Add(new Usuarios(
                    int.Parse(lector[0].ToString()),
                    lector[1].ToString(),
                    lector[2].ToString(),
                    lector[3].ToString()));
            }
            cmd.Connection.Close();
            lector.Close();
            return data;
        }

        public bool insertar(Usuarios u)
        {
            string sql = "insert into usuarios values(" + u.cod_user + ",'" + u.nombre_usuario + "','" + u.contra + "','" + u.nivel_usuario + "')";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();

            if (r == 1)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        //------------------ Actualizar y eliminar  ------------------------
        public bool actualizar(Usuarios u)
        {
            string sql = "UPDATE Usuarios SET nombre_usuario='" + u.nombre_usuario + "', contra='" + u.contra + "', nivel_usuario='" + u.nivel_usuario + "' WHERE cod_user=" + u.cod_user;
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }
        public bool eliminar(int cod_user)
        {
            string sql = "DELETE FROM Usuarios WHERE cod_user=" + cod_user;
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }
    }
}