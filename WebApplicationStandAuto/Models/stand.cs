namespace WebApplicationStandAuto.Models;

public class stand   // Definição das variaveis que fazem parte da tabela stand.
{
    private comprasContext context;

    public int idCarros { get; set; }

    public string marca { get; set; }

    public string modelo { get; set; }

    public int ano { get; set; }

    public string cor { get; set; }

    public string fonte_energia { get; set; }

    public string matricula { get; set; }

    public decimal preco_compra { get; set; }

    public DateTime data_compra { get; set; }

    public int quilometros { get; set; }

    public decimal preco_venda { get; set; }

}
