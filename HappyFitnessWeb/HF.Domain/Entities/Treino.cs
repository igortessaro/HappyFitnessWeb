namespace HF.Domain.Entities
{
    public class Treino
    {
        public int codTreino { get; set; }

        public int codAluno { get; set; }

        public int codInstrutor { get; set; }

        public string Tipo { get; set; }

        public string dataInicio { get; set; }

        public string dataFim { get; set; }
    }
}
