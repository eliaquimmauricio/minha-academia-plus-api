using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.MinhaAcademia.Domain.DTO
{
    public class Exercicio
    {
        public int Ordem { get; set; }
        public string? NomeExercicio { get; set; }
        public int QuantidadeDeSeries { get; set; }
        public int QuantidadeDeRepeticoes { get; set; }
        public double Carga { get; set; }
        public string? ObservacaoAluno { get; set; }
        public string? ObservacaoInstrutor { get; set; }
    }
}
