using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.MinhaAcademia.Domain.DTO
{
    public class Pessoa
    {
        public string? NomeCompleto { get; set; }
        public string? Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade => ((int)(DateTime.Now - DataNascimento).TotalDays) / 365;
    }
}
