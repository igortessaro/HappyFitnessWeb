using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class AcademiaService
    {
        public AcademiaService()
        {
            this.AcademiaRepository = new AcademiaRepository();
        }

        public AcademiaRepository AcademiaRepository { get; set; }

        public List<Academia> ObterTodasAcademias()
        {
            return this.AcademiaRepository.ConsultarTodos();
        }

        public string ObterPorParteDoNome(string like)
        {
            return this.AcademiaRepository.ConsultarLikeNome(like);
        }

    }
}
