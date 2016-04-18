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
        }

        public ExercicioService ExercicioService { get; set; }

        [HttpGet]
        public ExercicioDTO[] Obter(int pessoaCodigo)
        {
            return this.ExercicioService.ObterExercicos(pessoaCodigo).ToArray();
        }
    }
}
