using PUC.MinhaAcademia.Domain.DTO;
using PUC.MinhaAcademiaPlus.Domain.DTO;

namespace PUC.MinhaAcademiaPlus.Domain.Interfaces
{
    public interface IMainRepository
    {
        LoginResultado ConsultarLogin(string? usuario);
        Pessoa ConsultarDadosPessoais(int idLogin);
        List<DetalheFisico>? ConsultarDetalhesFisicos(int idLogin);
        List<Exercicio> ConsultarExercicios(int idLogin, int diaDaSemana);
    }
}
