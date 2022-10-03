namespace PUC.MinhaAcademiaPlus.Domain.DTO
{
    public class LoginResultado
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Senha { get; set; }
        public string? TipoUsuario { get; set; }
    }
}