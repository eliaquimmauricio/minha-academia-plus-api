namespace PUC.MinhaAcademiaPlus.API
{
    public static class SwaggerFactory
    {
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
        {
            return services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Minha Academia Plus",
                    Description = "API desenvolvida por Eliaquim Maurício como parte do projeto integrado do curso de Arquitetura de Software Distribuído ofertado pela PUC Minas."
                });
            });
        }
    }
}