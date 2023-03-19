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

            stand = context.GetAllstand();
        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();

            stand = context.GetAllstand();

                if (Request.Form["operacao"].Equals("updateStand"))
                {

                try
                {
                    stand stand = new stand()
                    {
                        idCarros = int.Parse(Request.Form["idCarros"]),
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

                    context.UpdateStand(stand);

                    OnGet();
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    OnGet();
                    return;
                }
                }
                else if (Request.Form["operacao"].Equals("delete"))
                {
                    context.deleteStand(Int32.Parse(Request.Form["idCarros"]));
                    OnGet();
                }      
        }

    }
}
