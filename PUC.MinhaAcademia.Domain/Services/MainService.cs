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

        public Aluno ConsultarDadosAluno()
        {
            if (_tipoUsuario != "Aluno")
                throw new SemAutorizacaoException("Essa rota esta disponível apenas para alunos.");

            return new Aluno
            {
                DadosPessoais = _mainRepository.ConsultarDadosPessoais(_idLogin),
                DetalhesFisicos = _mainRepository.ConsultarDetalhesFisicos(_idLogin),
                PlanosExercicios = new List<PlanoExercicios>
                {
                    new PlanoExercicios
                    {
                        Domingo = _mainRepository.ConsultarExercicios(_idLogin, 1),
                        Segunda = _mainRepository.ConsultarExercicios(_idLogin, 2),
                        Terca   = _mainRepository.ConsultarExercicios(_idLogin, 3),
                        Quarta  = _mainRepository.ConsultarExercicios(_idLogin, 4),
                        Quinta  = _mainRepository.ConsultarExercicios(_idLogin, 5),
                        Sexta   = _mainRepository.ConsultarExercicios(_idLogin, 6),
                        Sabado  = _mainRepository.ConsultarExercicios(_idLogin, 7),
                    }
                }
            };
        }
    }
}
