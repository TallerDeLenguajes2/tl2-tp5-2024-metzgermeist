public class PresupuestoDetalle
{
    int cantidad;
    Productos Producto;

    public PresupuestoDetalle(int cantidad, Productos producto)
    {
        this.cantidad = cantidad;
        Producto = producto;
    }

    public int Cantidad { get => cantidad; set => cantidad = value; }
    public Productos Producto1 { get => Producto; set => Producto = value; }
}