

namespace PUC.MinhaAcademiaPlus.API
{
    public static class EndpointsMapper
    {
        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/login", (MainService service, Login login) => service.Logar(login).CreateToken()).AllowAnonymous();
            app.MapGet("/aluno", (MainService service) => service.ConsultarDadosAluno()).RequireAuthorization();
            app.MapGet("/instrutor", (MainService service) => service.ConsultarDadosAlunosPorInstrutor()).RequireAuthorization();
            return app;
        }
    }
}