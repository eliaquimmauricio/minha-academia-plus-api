namespace PUC.MinhaAcademia.Domain.DTO
{
    public class Instrutor
    {
        public Pessoa? DadosPessoais { get; set; }
        public List<Aluno> Alunos { get; set; }

        public Instrutor()
        {
            Alunos = new List<Aluno>();
        }
    }
}
