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
        }

        public AcademiaService AcademiaService { get; set; }
        public AparelhoService AparelhoService { get; set; }
        public AtividadeService AtividadeService { get; set; }
        public ExercicioService ExercicioService { get; set; }
        public MusculoService MusculoService { get; set; }

        [HttpGet]
        public string GetValues()
        {
            string result = string.Empty;

            try
            {
                var academiaList = this.AcademiaService.ObterTodasAcademias();

                if(academiaList != null && academiaList.Any())
                {
                    result = string.Join(", ", academiaList.Select(a => a.Nome).ToArray());
                }
            }
            catch(Exception ex)
            {
                result = "Falha no engano";
            }

            return result;
        }

        public string TesteComPrametro(string palavra)
        {
            return this.AcademiaService.ObterPorParteDoNome(palavra);
        }
    }
}
