using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mysqlx;
using Org.BouncyCastle.Crypto.Tls;
using WebApplicationStandAuto.Models;

namespace WebApplicationStandAuto.Pages
{
    public class CreateStandModel : PageModel
    {
        public string ErrorMessage = "";
        public string ErrorMessage2= "";
        public string ErrorMessage3 = "";
        public string ErrorMessage4 = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
           

                stand Stand = new stand(); // Criação de objeto stand 

                Stand.marca = Request.Form["marca"];  // Adiciona o valor da caixa de texto a cada varivel do Objeto stad criado. 
                Stand.modelo = Request.Form["modelo"];
                try                                        // Estrutura try catch para proteção de erros ou dados mal inseridos.
                { 
                Stand.ano = Int32.Parse(Request.Form["ano"]); 
                }
                catch (Exception ex)
                {
                ErrorMessage = ex.Message;
                OnGet();
                return;
                }
                Stand.cor = Request.Form["cor"];
                Stand.fonte_energia = Request.Form["fonte_energia"];
                Stand.matricula = Request.Form["matricula"];
                try
                {
                Stand.preco_compra = Decimal.Parse(Request.Form["preco_compra"]);
                }
                catch (Exception ex)
                {
                ErrorMessage3 = ex.Message;
                OnGet();
                return;
                }
                Stand.data_compra = DateTime.Today;
                try
                {
                Stand.quilometros = Int32.Parse(Request.Form["quilometros"]);
                }
                catch (Exception ex)
                {
                ErrorMessage2 = ex.Message;
                OnGet();
                return;
                }
                try
                {
                Stand.preco_venda = Decimal.Parse(Request.Form["preco_venda"]);
                }
                catch (Exception ex)
                {
                ErrorMessage4 = ex.Message;
                OnGet();
                return;
                }
                comprasContext context = new comprasContext();

                context.createStand(Stand); // chama o metódo createStand e envia o objeto stand com as variveis inseridas nele. Ver metódo em comprasContext.cs  

                OnGet();
        }   
    }
}
