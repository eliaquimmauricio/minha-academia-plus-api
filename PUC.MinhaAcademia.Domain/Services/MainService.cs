using Microsoft.AspNetCore.Http;
using PUC.MinhaAcademia.Domain.DTO;
using PUC.MinhaAcademiaPlus.Domain.DTO;
using PUC.MinhaAcademiaPlus.Domain.Exceptions;
using PUC.MinhaAcademiaPlus.Domain.Interfaces;
using PUC.MinhaAcademiaPlus.Domain.Utils;

namespace PUC.MinhaAcademiaPlus.Domain.Services
{
    public class MainService
    {
        private readonly IMainRepository _mainRepository;
        private readonly IHttpContextAccessor? _httpContextAcessor;

        private readonly int _idLogin = -1;
        private readonly string _tipoUsuario = string.Empty;

        public MainService(IMainRepository mainRepository, IHttpContextAccessor httpContextAcessor)
        {
            _mainRepository = mainRepository;
            _httpContextAcessor = httpContextAcessor;

            _idLogin = _httpContextAcessor?.GetClaim<int>("id-login") ?? -1;
            _tipoUsuario = _httpContextAcessor?.GetClaim<string>("tipo-usuario") ?? string.Empty;
        }

        public LoginResultado Logar(Login login)
        {
            LoginResultado resultado = _mainRepository.ConsultarLogin(login.Usuario);

            if (resultado == null || resultado.Senha != login.Senha)
                throw new SemAutorizacaoException("Usuário ou senha incorretos.");

            return resultado;
        }

        public Aluno ConsultarDadosAluno(int idLogin = 0)
        {
            if (_tipoUsuario != "Aluno" && idLogin == 0)
                throw new SemAutorizacaoException("Essa rota esta disponível apenas para alunos.");

            if (idLogin == 0)
                idLogin = _idLogin;

            return new Aluno
            {
                DadosPessoais = _mainRepository.ConsultarDadosPessoais(idLogin),
                DetalhesFisicos = _mainRepository.ConsultarDetalhesFisicos(idLogin),
                PlanosExercicios = new List<PlanoExercicios>
                {
                    new PlanoExercicios
                    {
                        Domingo = _mainRepository.ConsultarExercicios(idLogin, 1),
                        Segunda = _mainRepository.ConsultarExercicios(idLogin, 2),
                        Terca   = _mainRepository.ConsultarExercicios(idLogin, 3),
                        Quarta  = _mainRepository.ConsultarExercicios(idLogin, 4),
                        Quinta  = _mainRepository.ConsultarExercicios(idLogin, 5),
                        Sexta   = _mainRepository.ConsultarExercicios(idLogin, 6),
                        Sabado  = _mainRepository.ConsultarExercicios(idLogin, 7),
                    }
                }
            };
        }

        public Instrutor ConsultarDadosAlunosPorInstrutor()
        {
            if (_tipoUsuario != "Instrutor")
                throw new SemAutorizacaoException("Essa rota esta disponível apenas para instrutores.");

            List<int> idsTodosAlunosPorInstrutor = _mainRepository.ConsultarIdsTodosOsAlunosPorInstrutor(_idLogin);

            Instrutor resultado = new Instrutor();

            foreach (var id in idsTodosAlunosPorInstrutor)
                resultado.Alunos.Add(ConsultarDadosAluno(id));

            resultado.DadosPessoais = _mainRepository.ConsultarDadosPessoais(_idLogin);

            return resultado;
        }
    }
}
