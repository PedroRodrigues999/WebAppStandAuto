using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationStandAuto.Models;

namespace WebApplicationStandAuto.Pages
{
    public class contabilidadeModel : PageModel
    {
        public decimal lucro=0;
        public decimal invest = 0;
        public decimal recebido = 0;
      
        public IEnumerable<contabilidade> contabilidade { get; set; }
        public void OnGet()
        {

            comprasContext context = new comprasContext();

            contabilidade = context.GetAllcontabilidade();

        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();

            if (Request.Form["operacao"].Equals("Atualizar"))
            {
                lucro = context.GetLucro();
                invest = context.GetInvestido();
                recebido = context.GetRecebido();
             
                OnGet();
            }
            else if (Request.Form["operacao"].Equals("delete"))
            {
                context.deleteContabilidade(Int32.Parse(Request.Form["idc"]));

                OnGet();
            }
        }
    }
}
