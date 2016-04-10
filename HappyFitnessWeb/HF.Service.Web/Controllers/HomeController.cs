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
        /// <summary>
        /// apenas para testar o swagger
        /// </summary>
        /// <returns>mensagem</returns>
        [HttpGet]
        public string Teste()
        {
            return "funcionou";
        }
    }
}
