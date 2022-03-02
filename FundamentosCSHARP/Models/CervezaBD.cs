using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP.Models
{
    internal class CervezaBD
    {
        //cadena de conexion de la DB
        private string connectionString = "Data Source=DESKTOP-A9NILT7;Initial Catalog=Pruebas;User=sa;Password=12345678";
        
        public List<Cerveza> Get()
        {
            List<Cerveza> cervezas = new List<Cerveza>();

            string query = "Select nombre, marca, alcohol, cantidad from cerveza";

            //using sirve para especificar los namespaces y para especificar un universo que queda solamente dentro de las 
            //llaves y el objeto que cree en ese using, morirá dentro de esas llaves
            using (SqlConnection connection =new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                //empezar la conexion
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); 

                //leer los resultados
                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    int cantidad = reader.GetInt32(3);
                    Cerveza cerveza = new Cerveza(cantidad,nombre);
                    cerveza.Alcohol = reader.GetInt32(2);
                    cerveza.Marca = reader.GetString(1);

                    //Agregar a la DB
                    cervezas.Add(cerveza);
                }
                //cerrar conexion y reader para liberar memoria
                reader.Close();
                connection.Close();
            }

            return cervezas;
        }
    
        //método de inserción
        public void Add(Cerveza cerveza)
        {
            string query = "INSERT INTO cerveza (nombre, marca, alcohol, cantidad) VALUES(@nombre, @marca, @alcohol, @cantidad)";

            using (var connection =new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Edit(Cerveza cerveza, int id)
        {
            string query = "UPDATE cerveza SET nombre=@nombre, marca=@marca, alcohol=@alcohol, cantidad=@cantidad WHERE id=@id";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM cerveza WHERE id=@id";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
        }


    }

}
