using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace examen1ds31_RH.Models
{
    public class DAOProducto
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAOProducto()
        {
            // ----------------------------Sourse ----------------------------------------------------------------------
            this.con.ConnectionString = @"Data Source = MAKIMA\SQLEXPRESSR; initial catalog=examen1ds31; integrated security=true";
            //----------------------------------------------------------------------------------------------------------

        }

        public List<Productos> GetTabla()
        {
            List<Productos> data = new List<Productos>();
            cmd.Connection = con;
            cmd.CommandText = "select * from Productos";
            cmd.Connection.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                data.Add(new Productos(
                    int.Parse(lector[0].ToString()),
                    lector[1].ToString(),
                    int.Parse(lector[2].ToString()),
                    int.Parse(lector[3].ToString()),
                    int.Parse(lector[4].ToString()),
                    lector[5].ToString()));
            }
            cmd.Connection.Close();
            lector.Close();
            return data;
        }
        
        public bool insertar(Productos p)
        {
            string sql = "insert into productos values(" + p.cod_prod + ",'" + p.descripcion + "','" + p.Precio_unit + "','" + p.existencia + "','" + p.garantia + "','" + p.nombre+ "')";
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
        public bool actualizar(Productos p) 
        {
            string sql = "UPDATE Productos SET descripcion='" + p.descripcion + "', existencia='" + p.existencia + "', Precio_unit='" + p.Precio_unit + "', garantia='" + p.garantia + "', nombre='" + p.nombre + "' WHERE cod_prod=" + p.cod_prod;
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }
        public bool eliminar(int cod_prod)
        {
            string sql = "DELETE FROM Productos WHERE cod_prod=" + cod_prod;
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }





    }
}