namespace WebApplicationStandAuto.Models;

public class vendas  // Definição das variaveis que fazem parte da tabela venas.
{
    private comprasContext context;

    public int idVendas { get; set; }

    public string marca { get; set; }

    public string modelo { get; set; }

    public int ano { get; set; }

    public string cor { get; set; }

    public string fonte_energia { get; set; }

    public string matricula { get; set; }

    public int quilometros { get; set; }

    public decimal preco_compra { get; set; }

    public decimal preco_venda { get; set; }

    public DateTime data_compra { get; set; }

    public DateTime data_venda { get; set; }

}
