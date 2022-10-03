using PUC.MinhaAcademia.Domain.DTO;
using PUC.MinhaAcademiaPlus.Domain.DTO;

namespace PUC.MinhaAcademiaPlus.API
{
    public static class SecurityFactory
    {
        private static SymmetricSecurityKey _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("8ef6bdebadf74667bce049cd2235f384"));

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _symmetricSecurityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            return services;
        }


        public static Token CreateToken(this LoginResultado result)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id-login", result.Id.ToString()),
                    new Claim("tipo-usuario", result.TipoUsuario ?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddMonths(12),
                SigningCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new Token
            {
                TokenAcesso = tokenHandler.WriteToken(token),
                DataHoraExpiracao = tokenDescriptor.Expires.Value.ToLocalTime(),
                TipoUsuario = result.TipoUsuario
            };
        }
    }
}