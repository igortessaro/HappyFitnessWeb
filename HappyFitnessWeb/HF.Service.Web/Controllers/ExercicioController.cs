using HF.DataTransferObject.Exercicio;
using HF.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HF.Service.Web.Controllers
{
    public class ExercicioController : ApiController
    {
        public ExercicioController()
        {
            this.ExercicioService = new ExercicioService();
            this.PessoaService = new PessoaService();
        }

        public ExercicioService ExercicioService { get; set; }

        public PessoaService PessoaService { get; set; }

        [HttpGet]
        public ExercicioDTO[] Obter(int pessoaCodigo)
        {
            return this.PessoaService.ObterTreino(pessoaCodigo).ToArray();
        }
    }
}
