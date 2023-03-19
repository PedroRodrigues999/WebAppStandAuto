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

            compras = context.GetAllcompras();

        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();



            if (Request.Form["operacao"].Equals("Comprar"))
            {
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

                context.deleteCompra(Int32.Parse(Request.Form["idCompras"]));

                OnGet();

            }
            else if (Request.Form["operacao"].Equals("searchByMarca"))
            {
                this.compras = context.searchByMarca(Request.Form["caixa"]);
               

            }
            else if (Request.Form["operacao"].Equals("searchByAno2"))
            {
                try { this.compras = context.searchByAno2(Int32.Parse(Request.Form["caixa"])); }
                catch (Exception ex)
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
                    this.compras = context.searchByKM(Int32.Parse(Request.Form["caixa"]));
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
                try
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
