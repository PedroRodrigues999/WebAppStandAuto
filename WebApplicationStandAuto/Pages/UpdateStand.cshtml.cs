using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using WebApplicationStandAuto.Models;


namespace WebApplicationStandAuto.Pages
{
    public class UpdateStandModel : PageModel
    {
        public string ErrorMessage = "";
        public IEnumerable<stand> stand { get; set; }

        public void OnGet()
        {
            comprasContext context = new comprasContext();

            stand = context.GetAllstand();  // Ao abrir a pagina vai buscar os dados da tabela stand gra�as ao met�do GetAllstand que est� no comprasContext.cs
        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();

            stand = context.GetAllstand();

                if (Request.Form["operacao"].Equals("updateStand")) // Em updatestand � possivel alterar/atualizar as carecteristicas dos carros, 
                {                                                      

                try
                {
                    stand stand = new stand()      //Cria novo objeto stand 
                    {
                        idCarros = int.Parse(Request.Form["idCarros"]),  // recolhe valores do Form
                        marca = Request.Form["marca"],
                        modelo = Request.Form["modelo"],
                        ano = int.Parse(Request.Form["ano"]),
                        cor = Request.Form["cor"],
                        fonte_energia = Request.Form["fonte_energia"],
                        matricula = Request.Form["matricula"],
                        preco_compra = Decimal.Parse(Request.Form["preco_compra"]),                     
                        quilometros = int.Parse(Request.Form["quilometros"]),
                        preco_venda = Decimal.Parse(Request.Form["preco_venda"]),
                    };

                    context.UpdateStand(stand); // Chama met�do UpdateStand que recebe os valores do Form e escreve esse novos valores na Base de dados 

                    OnGet();
                }
                catch (Exception ex)  // Estrutuda try Catch para prote��o de dados mal inseridos.
                {
                    ErrorMessage = ex.Message;
                    OnGet();
                    return;
                }
                }
                else if (Request.Form["operacao"].Equals("delete")) // Tamb�m � possivel apagar um Objeto Stand aqui
                {
                    context.deleteStand(Int32.Parse(Request.Form["idCarros"])); // atraves do m�t�do deleteStand que recebe idCarros, seu identificador. 
                    OnGet();
                }      
        }

    }
}
