

namespace PUC.MinhaAcademiaPlus.API
{
    public static class DependencyInjector
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            return services.AddTransient<MainService>()
                           .AddTransient<Context>()
                           .AddTransient<IMainRepository, MainRepository>();
        }
    }
}