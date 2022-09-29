using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.MinhaAcademia.Domain.DTO
{
    public class PlanoExercicios
    {
        public List<Exercicio>? Domingo { get; set; }
        public List<Exercicio>? Segunda { get; set; }
        public List<Exercicio>? Terca { get; set; }
        public List<Exercicio>? Quarta { get; set; }
        public List<Exercicio>? Quinta { get; set; }
        public List<Exercicio>? Sexta { get; set; }
        public List<Exercicio>? Sabado { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
    }
}
