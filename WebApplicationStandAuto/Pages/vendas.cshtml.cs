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

            vendas = context.GetAllvendas(); // Ao abrir a pagina vai buscar os dados da tabela vendas graças ao metódo GetAllvendas que está no comprasContext.cs

        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();

            if (Request.Form["operacao"].Equals("Contabilidade")) // Ao carregar no Botão Contas cria um objeto contabilidade recolhe os valores do form de vendas e cria novo elemento na tabela
            {                                                     //  contabilidade.
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

                context.create_Contabilidade(contabilidade); // Chama metódo para adicionar nova linha a tabela contabilidade.

                OnGet();

            }
            else if (Request.Form["operacao"].Equals("delete")) // É possivel apagar vendas atraves do metódo deleteVendas. 
            {
                context.deleteVendas(Int32.Parse(Request.Form["idVendas"]));

                OnGet();
            }
        }

    }
}
