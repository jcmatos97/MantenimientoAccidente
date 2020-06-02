using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MantenimientoAccidente
{
    public class DatabaseOPS
    {
        private Conexion conn;
        SqlCommand comando = new SqlCommand();
        public DatabaseOPS(Conexion conn)
        {
            this.conn = conn;
        }
        public bool Create(Accidente a)
        {
            try
            {
                comando.Connection = conn.AbrirConexion();
                comando.CommandText = "insert into accidente values(@nombre,@apellido,@edad,@sexo,@accidente,@estado,@foto,@lesion,@direccion,@detalle)";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@nombre", a.nombre);
                comando.Parameters.AddWithValue("@apellido", a.apellido);
                comando.Parameters.AddWithValue("@edad", a.edad);
                comando.Parameters.AddWithValue("@sexo", a.sexo);
                comando.Parameters.AddWithValue("@accidente", a.accidente);
                comando.Parameters.AddWithValue("@estado", a.estado);
                comando.Parameters.AddWithValue("@foto", a.foto);
                comando.Parameters.AddWithValue("@lesion", a.lesion);
                comando.Parameters.AddWithValue("@direccion", a.direccion);
                comando.Parameters.AddWithValue("@detalle", a.detalle);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conn.CerrarConexion();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Accidente> Read()
        {
            try
            {
                var accidentes = new List<Accidente>();

                comando.Connection = conn.AbrirConexion();
                comando.CommandText = "select * from accidente";
                comando.CommandType = CommandType.Text;
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    accidentes.Add(
                        new Accidente
                        {
                            id = (int)reader["id"],
                            nombre = (string)reader["nombre"],
                            apellido = (string)reader["apellido"],
                            edad = (int)reader["edad"],
                            sexo = (int)reader["sexo"],
                            accidente = reader["accidente"].ToString(),
                            estado = (int)reader["estado"],
                            foto = (string)reader["foto"],
                            lesion = (string)reader["lesion"],
                            direccion = (string)reader["direccion"],
                            detalle = (string)reader["detalle"],
                        }
                    );
                }
                conn.CerrarConexion();
                return accidentes;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Accidente Read(int id)
        {
            try
            {
                var accidentes = new List<Accidente>();

                comando.Connection = conn.AbrirConexion();
                comando.CommandText = "select * from accidente where id=" + id;
                comando.CommandType = CommandType.Text;
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    accidentes.Add(
                        new Accidente
                        {
                            id = (int)reader["id"],
                            nombre = (string)reader["nombre"],
                            apellido = (string)reader["apellido"],
                            edad = (int)reader["edad"],
                            sexo = (int)reader["sexo"],
                            accidente = reader["accidente"].ToString(),
                            estado = (int)reader["estado"],
                            foto = (string)reader["foto"],
                            lesion = (string)reader["lesion"],
                            direccion = (string)reader["direccion"],
                            detalle = (string)reader["detalle"],
                        }
                    );
                }
                conn.CerrarConexion();
                return accidentes[0];

            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Update(Accidente a)
        {
            try
            {
                comando.Connection = conn.AbrirConexion();
                comando.CommandText = "update accidente set nombre=@nombre,apellido=@apellido,edad=@edad,sexo=@sexo,accidente=@accidente,estado=@estado,foto=@foto,lesion=@lesion,direccion=@direccion,detalle=@detalle where id=" + a.id;
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@nombre", a.nombre);
                comando.Parameters.AddWithValue("@apellido", a.apellido);
                comando.Parameters.AddWithValue("@edad", a.edad);
                comando.Parameters.AddWithValue("@sexo", a.sexo);
                comando.Parameters.AddWithValue("@accidente", a.accidente);
                comando.Parameters.AddWithValue("@estado", a.estado);
                comando.Parameters.AddWithValue("@foto", a.foto);
                comando.Parameters.AddWithValue("@lesion", a.lesion);
                comando.Parameters.AddWithValue("@direccion", a.direccion);
                comando.Parameters.AddWithValue("@detalle", a.detalle);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conn.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                comando.Connection = conn.AbrirConexion();
                comando.CommandText = "delete from accidente where id=" + id;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                conn.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class Conexion
    {
        private SqlConnection conn = new SqlConnection("Server=JC-STATION;DataBase=crudaccidente;Integrated Security=true");
        public SqlConnection AbrirConexion()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }
        public SqlConnection CerrarConexion()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }
    }
}