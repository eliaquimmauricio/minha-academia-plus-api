using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.MinhaAcademia.Domain.DTO
{
    public class Token
    {
        public string? TokenAcesso { get; set; }
        public DateTime DataHoraExpiracao { get; set; }
        public string? TipoUsuario { get; set; }        
    }
}
