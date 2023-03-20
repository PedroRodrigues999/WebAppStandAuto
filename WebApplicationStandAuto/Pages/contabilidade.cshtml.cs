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

            contabilidade = context.GetAllcontabilidade();  // Ao abrir a pagina vai buscar os dados da tabela contabilidade graças ao metódo GetAllcontabilidade que está no comprasContext.cs

        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();

            if (Request.Form["operacao"].Equals("Atualizar")) // Ao carregar no botão atualizar da pagina contabilidade vai chamar os seguintes metódos.
            {                                                 // para calcular Lucro total, Total Investido e total recebido.
                lucro = context.GetLucro();                   // o coneudo dos metódos está em comprasContext.cs
                invest = context.GetInvestido();
                recebido = context.GetRecebido();
             
                OnGet();
            }
            else if (Request.Form["operacao"].Equals("delete")) // Ao carregar em Apagar atraves do metódo deleteContabilidade apaga da base de dados o respetivo Carro selecionado. 
            {                                                   // Metódo encontra-se em comprasContext.cs
                context.deleteContabilidade(Int32.Parse(Request.Form["idc"]));

                OnGet();
            }
        }
    }
}
