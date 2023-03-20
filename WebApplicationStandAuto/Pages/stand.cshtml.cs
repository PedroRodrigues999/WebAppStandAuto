using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Asn1.Ocsp;
using WebApplicationStandAuto.Models;

namespace WebApplicationStandAuto.Pages
{
    public class standModel : PageModel
    {

        public IEnumerable<stand> stand { get; set; }
        public void OnGet()
        {

            comprasContext context = new comprasContext();

            stand = context.GetAllstand(); // Ao abrir a pagina vai buscar os dados da tabela stand graças ao metódo GetAllstand que está no comprasContext.cs

        }


        public void OnPost()
        {
            comprasContext context = new comprasContext();

            

            if (Request.Form["operacao"].Equals("vender"))  // Ao carregar em vender cria um novo objeto venda e adiciona as suas variaveis os elementos da tabela/Form  
            {                                              // e cria assim um elemento/Carro na tabela vendas atraves do metódo create_vendas                     
                vendas venda = new vendas();

                
                venda.marca = Request.Form["marca"];
                venda.modelo = Request.Form["modelo"];
                venda.ano = Int32.Parse(Request.Form["ano"]);
                venda.cor = Request.Form["cor"];
                venda.fonte_energia = Request.Form["fonte_energia"];
                venda.matricula = Request.Form["matricula"];
                venda.preco_compra = Decimal.Parse(Request.Form["preco_compra"]);
                venda.data_compra = DateTime.Parse(Request.Form["data_compra"]);
                venda.quilometros = Int32.Parse(Request.Form["quilometros"]);
                venda.preco_venda = Decimal.Parse(Request.Form["preco_venda"]);
                venda.data_venda = DateTime.Today;


                context.create_vendas(venda);

                OnGet();

                context.deleteStand(Int32.Parse(Request.Form["idCarros"]));

                OnGet();

            }
           else if (Request.Form["operacao"].Equals("delete"))
            {
                context.deleteStand(Int32.Parse(Request.Form["idCarros"])); // Apaga o Carro selecionado atraves do metódo deleteStand que recebe idCarros que é o indentificador do carro a apagar.

                OnGet();
            }
        

        }

    }

}
