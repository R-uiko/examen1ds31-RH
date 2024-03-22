using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace examen1ds31_RH.Models
{
    public class DAOCliente
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAOCliente()
        {
            this.con.ConnectionString = @"Data Source=MAKIMA\SQLEXPRESSR; initial catalog=examen1ds31; integrated security=true";
        }

        public List<Clientes> GetTabla()
        {
            List<Clientes> data = new List<Clientes>();
            cmd.Connection = con;
            cmd.CommandText = "select * from Clientes";
            cmd.Connection.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                data.Add(new Clientes(
                    lector[0].ToString(),
                    lector[1].ToString(),
                    lector[2].ToString(),
                    lector[3].ToString(),
                    lector[4].ToString(),
                    lector[5].ToString()));
            }
            cmd.Connection.Close();
            lector.Close();
            return data;
        }

        public bool Insertar(Clientes c)
        {
            string sql = "insert into clientes values('" + c.cod_clientes + "','" + c.nombres + "','" + c.apellidos + "','" + c.dui + "','" + c.direccion + "','" + c.nit + "')";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }

        public bool Actualizar(Clientes c)
        {
            string sql = "UPDATE Clientes SET nombres='" + c.nombres + "', apellidos='" + c.apellidos + "', dui='" + c.dui + "', direccion='" + c.direccion + "', nit='" + c.nit + "' WHERE cod_clientes='" + c.cod_clientes + "'";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }

        public bool Eliminar(string cod_clientes)
        {
            string sql = "deleted from Clientes where cod_clientes='" + cod_clientes + "'";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }

        public bool EliminarCliente(int idCliente)
        {
            bool eliminado = false;

            try
            {
                // Abrir la conexión a la base de datos
                con.Open();

                // Configurar la consulta SQL para eliminar el cliente
                string sql = "DELETE FROM clientes WHERE cod_cliente = @id";
                cmd = new SqlCommand(sql, con);

                // Añadir el parámetro ID a la consulta SQL
                cmd.Parameters.AddWithValue("@id", idCliente);

                // Ejecutar la consulta SQL
                int rowsAffected = cmd.ExecuteNonQuery();

                // Verificar si se eliminó correctamente (al menos una fila afectada)
                eliminado = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error y registrar la excepción si ocurre
                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                con.Close();
            }

            return eliminado;
        }



        public Clientes ObtenerClientePorId(int id)
    {
          // Agregar el parámetro de ID a la consulta para no estar confundiendo con el cod
            string query = "select * from clientes where cod_cliente = @id";

       
        using (SqlConnection connection = new SqlConnection(con.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@id", id);

                try
                {
             
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // verifica si se encontro el cliente
                    if (reader.Read())
                    {
                    
                        Clientes cliente = new Clientes
                        {
                            cod_clientes = reader["cod_cliente"].ToString(),
                            nombres = Convert.ToString(reader["nombres"]),
                            apellidos = Convert.ToString(reader["apellidos"]),
                            dui = Convert.ToString(reader["dui"]),
                            direccion = Convert.ToString(reader["direccion"]),
                            nit = Convert.ToString(reader["nit"])
                        };

                        // Retornar el objeto Cliente
                        return cliente;
                    }
                    else
                    {
                   
                        return null;
                    }
                }
                catch (Exception ex)
                {
           
                    Console.WriteLine("Error al obtener el cliente: " + ex.Message);
                    return null;
                }
            }
        }
    }
    }
}