public class Presupuestos
{
    private int idPresupuesto;
    private string NombreDestinatario;
    private List<PresupuestoDetalle> detalle;

    private DateTime fecha;
    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario1 { get => NombreDestinatario; set => NombreDestinatario = value; }
    public List<PresupuestoDetalle> Detalle { get => detalle; set => detalle = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }

    public Presupuestos()
    {
       
    }

    public int MontoPresupuesto()
    {
        int monto=1;

        return monto;
    }

    public int MontoPresupuestoConIva()
    {
        int MontoPre=1;

        return MontoPre;
    }
    
    public int CantidadProductos()
    {
        int cantidadP=1;

        return cantidadP;
    }
    


}