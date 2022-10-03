using PUC.MinhaAcademia.Domain.DTO;
using PUC.MinhaAcademiaPlus.Domain.DTO;
using PUC.MinhaAcademiaPlus.Domain.Interfaces;
using Tasken.SRC.Infra.Data;

namespace PUC.MinhaAcademiaPlus.Infra.Data
{
    public class MainRepository : BaseRepository, IMainRepository
    {
        public MainRepository(Context context) : base(context)
        {
        }

        public Pessoa ConsultarDadosPessoais(int idLogin)
        {
            const string sql = @"SELECT NomeCompleto, Apelido, DataNascimento FROM DadosPessoais(NOLOCK) WHERE IdUsuarios = @idLogin";

            return QueryFirstOrDefault<Pessoa>(sql, new { idLogin });
        }

        public List<DetalheFisico>? ConsultarDetalhesFisicos(int idLogin)
        {
            const string sql = @"SELECT Peso, PercentualGordura, Observacao, DataHoraCadastro FROM DetalhesFisicos(NOLOCK) WHERE IdUsuarios = @idLogin ORDER BY DataHoraCadastro DESC";

            return Query<DetalheFisico>(sql, new { idLogin });
        }

        public List<Exercicio> ConsultarExercicios(int idLogin, int diaDaSemana)
        {
            const string sql = @"SELECT DiaDaSemana, Ordem, NomeExercicio, QuantidadeDeSeries, QuantidadeDeRepeticoes, Carga, ObservacaoAluno, ObservacaoInstrutor FROM Exercicios(NOLOCK) WHERE IdUsuarios = @idLogin AND DiaDaSemana = @diaDaSemana ORDER BY Ordem ASC";

            return Query<Exercicio>(sql, new { idLogin, diaDaSemana });
        }

        public LoginResultado ConsultarLogin(string? usuario)
        {
            const string sql = @"SELECT Id, Usuario, Senha, TipoUsuario FROM Usuarios(NOLOCK) WHERE Usuario = @usuario";

            return QueryFirstOrDefault<LoginResultado>(sql, new { usuario });
        }
    }
}
