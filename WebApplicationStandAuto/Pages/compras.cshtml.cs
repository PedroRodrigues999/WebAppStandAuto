using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;
using WebApplicationStandAuto.Models;

namespace WebApplicationStandAuto.Pages
{
    public class comprasModel : PageModel
    {
        public string ErrorMessage = "";
        public string ErrorMessage2 = "";
        public string ErrorMessage3 = "";

        public IEnumerable<compras> compras { get; set; }

        public void OnGet()
        {
            comprasContext context = new comprasContext();

            compras = context.GetAllcompras(); // Ao abrir a pagina vai buscar os dados da tabela compras graças ao metódo GetAllcompras que está no comprasContext.cs

        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();



            if (Request.Form["operacao"].Equals("Comprar")) // Ao carregar no botão Comprar pega nas variaveis que estão na tabela/form e coloca-as num objeto compra que enviado para 
            {                                               // o metódo create_compra que está em comprasContext.cs
                stand compra = new stand();


                compra.marca = Request.Form["marca"];
                compra.modelo = Request.Form["modelo"];
                compra.ano = Int32.Parse(Request.Form["ano"]);
                compra.cor = Request.Form["cor"];
                compra.fonte_energia = Request.Form["fonte_energia"];
                compra.matricula = Request.Form["matricula"];
                compra.preco_compra = Decimal.Parse(Request.Form["preco"]);
                compra.data_compra = DateTime.Today;
                compra.quilometros = Int32.Parse(Request.Form["quilometros"]);
                compra.preco_venda = 0;
                 


                context.create_compra(compra);

                OnGet();

                context.deleteCompra(Int32.Parse(Request.Form["idCompras"])); // Apaga também o carro da tabela compras logo depois de ser comprado. 
                                                                              // deleteCompra recebe o idCompras para saber qual o carro a apagar. 
                OnGet();                                                      // o metódo está em comprasContext.cs

            }
            else if (Request.Form["operacao"].Equals("searchByMarca")) //Atraves do Select que no comprar.cshtml e acionado o searchByMarca.
            {
                this.compras = context.searchByMarca(Request.Form["caixa"]); // Envia o valor que é colocado na caixa de texto para o metódo searchByMarca que está em comprasContext.cs
               

            }
            else if (Request.Form["operacao"].Equals("searchByAno2"))  // Consuante a escolha do select escolhe o metódo e envia respetivo valor da caixa de texto.
            {
                try { this.compras = context.searchByAno2(Int32.Parse(Request.Form["caixa"])); } // Envia mensagem de erro se for introduzido uma ou varias letra pois é esperado um número
                catch (Exception ex)                                                             // para fazer a converção/Parse para inteiro, é uma proteção para a webapp não rebentar. 
                {
                    ErrorMessage = ex.Message;
                    OnGet();
                    return;
                }
            }
            else if (Request.Form["operacao"].Equals("searchByModelo"))
            {
                this.compras = context.searchByModelo(Request.Form["caixa"]);
            }
            else if (Request.Form["operacao"].Equals("searchByCor"))
            {
                this.compras = context.searchByCor(Request.Form["caixa"]);
            }
            else if (Request.Form["operacao"].Equals("searchByFonte"))
            {
                this.compras = context.searchByFonte(Request.Form["caixa"]);
            }
            else if (Request.Form["operacao"].Equals("searchByMatricula"))
            {
                this.compras = context.searchByMatricula(Request.Form["caixa"]);
            }
            else if (Request.Form["operacao"].Equals("searchByKM"))
            {
                try { 
                    this.compras = context.searchByKM(Int32.Parse(Request.Form["caixa"])); // try Catch para apanhar erros, proteção para a webapp não rebentar.
                }
                catch (Exception ex)
                    {
                    ErrorMessage2 = ex.Message;
                    OnGet();
                    return;
                    }
            }
            else if (Request.Form["operacao"].Equals("searchByPreco"))
            {
                try                                                                      // try Catch para apanhar erros, proteção para a webapp não rebentar.
                {
                    this.compras = context.searchByPreco(Decimal.Parse(Request.Form["caixa"]));
                }
                catch (Exception ex)
                {
                    ErrorMessage3 = ex.Message;
                    OnGet();
                    return;
                }
            }
        }
    }
}
