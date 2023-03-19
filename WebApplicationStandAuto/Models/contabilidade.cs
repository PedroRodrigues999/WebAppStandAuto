namespace WebApplicationStandAuto.Models
{
    public class contabilidade
    {

        private comprasContext context;

        public int idc { get; set; }

        public string marca { get; set; }

        public string modelo { get; set; }

        public int ano { get; set; }

        public string cor { get; set; }

        public string fonte_energia { get; set; }

        public string matricula { get; set; }

        public int quilometros { get; set; }

        public decimal preco_compra { get; set; }

        public decimal preco_venda { get; set; }

        public decimal lucro_carro { get; set; }

        public DateTime data_compra { get; set; }

        public DateTime data_venda { get; set; }

        public double tempo_stand { get; set; }

    }
}
