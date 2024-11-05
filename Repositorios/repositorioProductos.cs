using System.Data.SQLite;

public class repositorioProductos
{
    private readonly string cadenaDeConexion = "Data Source=DB/Tienda.db";

    public void CrearProducto(Productos NuevoProducto)
    {
        var query = $"INSERT INTO Productos( string descripcion, int precio) VALUES(@descripcion,@precio)";

        using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
        {
            conexion.Open();

            var command = new SQLiteCommand(query, conexion);

            command.Parameters.Add(new SQLiteParameter("@descripcion", NuevoProducto.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@precio", NuevoProducto.Precio));

            command.ExecuteNonQuery();

            conexion.Close();
        }

    }

    public bool ModificarProducto(int idProductoModificar, Productos ProductoModificar)
    {
        bool productoActualizado = false;

        var query = $"UPDATE Productos SET Descripcion = @NuevaDescripcion, Precio =@NuevoPrecio WHERE idProducto = @idProductoModificar";

        using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
        {
            conexion.Open();

            var command = new SQLiteCommand(query, conexion);

            command.Parameters.Add(new SQLiteParameter("@NuevaDescripcion", ProductoModificar.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@NuevoPrecio", ProductoModificar.Precio));
            command.Parameters.Add(new SQLiteParameter("@idProductoModificar", idProductoModificar));

            if (command.ExecuteNonQuery() > 0)
            {
                productoActualizado = true;
            }

            conexion.Close();
        }
        return productoActualizado;

    }

    public List<Productos> GetlistaProdcutos()
    {
        List<Productos> TodosLosProductos = new List<Productos>();

        var query = $"SELECT * FROM Productos ";

        using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
        {
            conexion.Open();

            var command = new SQLiteCommand(query, conexion);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    Productos producto = new Productos
                    {
                        IdProdcudto = reader.GetInt32(reader.GetOrdinal("idProducto")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                        Precio = reader.GetInt32(reader.GetOrdinal("Precio"))
                    };

                    TodosLosProductos.Add(producto);
                }
            }



            conexion.Close();
        }
        return TodosLosProductos;

    }

    public Productos GetProductoID(int idProductoBuscado)
    {

        var query = $"SELECT * FROM Productos  WHERE idProducto = @idProductoBuscado";

        Productos productoBuscado = null;

        using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
        {
            conexion.Open();

            var command = new SQLiteCommand(query, conexion);
            command.Parameters.Add(new SQLiteParameter("@idProductoBuscado", idProductoBuscado));
        
            return productoBuscado;
        }

    }

    public void EliminarProducto(int idaEliminar)
    {
        

        var query = $"DELETE FROM Productos  WHERE idProducto = @idaEliminar";

        using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
        {
            conexion.Open();
            
            var command = new SQLiteCommand(query, conexion);
            
            command.Parameters.Add(new SQLiteParameter("@idaEliminar", idaEliminar));

            command.ExecuteNonQuery();

            conexion.Close();


        }

    }
}