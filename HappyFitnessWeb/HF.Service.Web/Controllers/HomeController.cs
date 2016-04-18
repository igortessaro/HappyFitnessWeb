using HF.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HF.Service.Web.Controllers
{
    public class HomeController : ApiController
    {
        public HomeController()
        {
            this.AcademiaService = new AcademiaService();
            this.AparelhoService = new AparelhoService();
            this.AtividadeService = new AtividadeService();
            this.ExercicioService = new ExercicioService();
            this.MusculoService = new MusculoService();
            this.PessoaService = new PessoaService();
            this.TreinoService = new TreinoService();
            this.TreinoDiarioService = new TreinoDiarioService();
        }

        public AcademiaService AcademiaService { get; set; }
        public AparelhoService AparelhoService { get; set; }
        public AtividadeService AtividadeService { get; set; }
        public ExercicioService ExercicioService { get; set; }
        public MusculoService MusculoService { get; set; }
        public PessoaService PessoaService { get; set; }
        public TreinoService TreinoService { get; set; }
        public TreinoDiarioService TreinoDiarioService { get; set; }

        [HttpGet]
        public string GetValues()
        {
            string result = string.Empty;

            try
            {
                var academiaList = this.AcademiaService.ObterTodasAcademias();

                if (academiaList != null && academiaList.Any())
                {
                    result = string.Join(", ", academiaList.Select(a => a.Nome).ToArray());
                }
            }
            catch (Exception ex)
            {
                result = this.ObterMensagemErro(ex);
            }

            return result;
        }

        private string ObterMensagemErro(Exception ex)
        {
            if (ex.InnerException == null) return ex.Message;

            return this.ObterMensagemErro(ex.InnerException);
        }

        public string TesteComPrametro(string palavra)
        {
            return this.AcademiaService.ObterPorParteDoNome(palavra);
        }
    }
}
