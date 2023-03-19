using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationStandAuto.Models;

namespace WebApplicationStandAuto.Pages
{
    public class vendasModel : PageModel
    {

        public IEnumerable<vendas> vendas { get; set; }
        public void OnGet()
        {

            comprasContext context = new comprasContext();

            vendas = context.GetAllvendas();

        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();

            if (Request.Form["operacao"].Equals("Contabilidade"))
            {
                contabilidade contabilidade = new contabilidade();

                contabilidade.marca = Request.Form["marca"];
                contabilidade.modelo = Request.Form["modelo"];
                contabilidade.ano = Int32.Parse(Request.Form["ano"]);             
                contabilidade.matricula = Request.Form["matricula"];
                contabilidade.preco_compra = Decimal.Parse(Request.Form["preco_compra"]);
                contabilidade.preco_venda = Decimal.Parse(Request.Form["preco_venda"]);
                contabilidade.lucro_carro = contabilidade.preco_venda-contabilidade.preco_compra;
                contabilidade.data_compra = DateTime.Parse(Request.Form["data_compra"]);
                contabilidade.data_venda = DateTime.Parse(Request.Form["data_venda"]);
                contabilidade.tempo_stand = Math.Round((contabilidade.data_venda - contabilidade.data_compra).TotalDays,0);

                context.create_Contabilidade(contabilidade);

                OnGet();

            }
            else if (Request.Form["operacao"].Equals("delete"))
            {
                context.deleteVendas(Int32.Parse(Request.Form["idVendas"]));

                OnGet();
            }
        }

    }
}
