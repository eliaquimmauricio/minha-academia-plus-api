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

        private readonly string _idLogin = string.Empty;
        private readonly string _tipoUsuario = string.Empty;

        public MainService(IMainRepository mainRepository, IHttpContextAccessor httpContextAcessor)
        {
            _mainRepository = mainRepository;
            _httpContextAcessor = httpContextAcessor;

            _idLogin = _httpContextAcessor?.GetClaim<string>("id-login") ?? string.Empty;
            _tipoUsuario = _httpContextAcessor?.GetClaim<string>("tipo-usuario") ?? string.Empty;
        }

        public LoginResultado Logar(Login login)
        {
            return new LoginResultado
            {
                Id = Guid.NewGuid().ToString(),
                TipoUsuario = "Aluno"
            };
        }

        public Aluno ConsultarDadosAluno()
        {
            if (_tipoUsuario != "Aluno")
                throw new SemAutorizacaoException("Essa rota esta disponível apenas para alunos.");

            //TODO: Adicionar aqui a consulta dos dados do aluno;

            return new Aluno
            {
                DadosPessoais = new Pessoa
                {
                    NomeCompleto = "Eliaquim Dos Santos",
                    Apelido = "Brabo",
                    DataNascimento = DateTime.Now
                },
                DetalhesFisicos = new List<Corpo>
                {
                    new Corpo
                    {
                        DataHoraCadastro = DateTime.Now,                        
                        Observacao = "Blablabla",
                        PercentualGordura = 1,
                        Peso = 83.4
                    }
                },
                PlanosExercicios = new List<PlanoExercicios>
                {
                    new PlanoExercicios
                    {
                        Segunda = new List<Exercicio>
                        {
                            new Exercicio
                            {
                                NomeExercicio = "Rosca Biceps",
                                QuantidadeDeSeries = 4,
                                QuantidadeDeRepeticoes = 10,
                                Ordem = 1
                            },
                            new Exercicio
                            {
                                NomeExercicio = "Supino Reto",
                                QuantidadeDeSeries = 4,
                                QuantidadeDeRepeticoes = 10,
                                Ordem = 1
                            }
                        },
                        Quarta = new List<Exercicio>
                        {
                            new Exercicio
                            {
                                NomeExercicio = "Rosca Biceps",
                                QuantidadeDeSeries = 4,
                                QuantidadeDeRepeticoes = 10,
                                Ordem = 1
                            },
                            new Exercicio
                            {
                                NomeExercicio = "Supino Reto",
                                QuantidadeDeSeries = 4,
                                QuantidadeDeRepeticoes = 10,
                                Ordem = 1
                            }
                        },
                        Sexta = new List<Exercicio>
                        {
                            new Exercicio
                            {
                                NomeExercicio = "Rosca Biceps",
                                QuantidadeDeSeries = 4,
                                QuantidadeDeRepeticoes = 10,
                                Ordem = 1
                            },
                            new Exercicio
                            {
                                NomeExercicio = "Supino Reto",
                                QuantidadeDeSeries = 4,
                                QuantidadeDeRepeticoes = 10,
                                Ordem = 1
                            }
                        }
                    }
                    }
            };
        }

    }
}
