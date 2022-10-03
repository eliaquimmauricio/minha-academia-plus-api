namespace PUC.MinhaAcademia.Domain.DTO
{
    public class Aluno
    {
        public Pessoa? DadosPessoais { get; set; }
        public List<PlanoExercicios>? PlanosExercicios { get; set; }  
        public List<DetalheFisico>? DetalhesFisicos { get; set; }
    }
}