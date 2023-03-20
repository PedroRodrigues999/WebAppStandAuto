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

            contabilidade = context.GetAllcontabilidade();  // Ao abrir a pagina vai buscar os dados da tabela contabilidade gra�as ao met�do GetAllcontabilidade que est� no comprasContext.cs

        }

        public void OnPost()
        {
            comprasContext context = new comprasContext();

            if (Request.Form["operacao"].Equals("Atualizar")) // Ao carregar no bot�o atualizar da pagina contabilidade vai chamar os seguintes met�dos.
            {                                                 // para calcular Lucro total, Total Investido e total recebido.
                lucro = context.GetLucro();                   // o coneudo dos met�dos est� em comprasContext.cs
                invest = context.GetInvestido();
                recebido = context.GetRecebido();
             
                OnGet();
            }
            else if (Request.Form["operacao"].Equals("delete")) // Ao carregar em Apagar atraves do met�do deleteContabilidade apaga da base de dados o respetivo Carro selecionado. 
            {                                                   // Met�do encontra-se em comprasContext.cs
                context.deleteContabilidade(Int32.Parse(Request.Form["idc"]));

                OnGet();
            }
        }
    }
}
