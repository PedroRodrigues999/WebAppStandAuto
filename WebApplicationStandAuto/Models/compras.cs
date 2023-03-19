namespace WebApplicationStandAuto.Models;

public class compras
{
    private comprasContext context;

    public int idCompras { get; set; }

    public string marca { get; set; }

    public string modelo { get; set; }

    public int ano { get; set; }

    public string cor { get; set; }

    public string fonte_energia { get; set; }

    public string matricula { get; set; }

    public int quilometros { get; set; }

    public decimal preco { get; set; }
}
