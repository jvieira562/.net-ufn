using Microsoft.AspNetCore.Identity;

namespace AmigoSecreto.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto { get; set; }
        public string PrimeiroNome { get; set; }
        public RedesSociais RedeSocial { get; set; } = RedesSociais.NaoContem;
        public string RedeSocialUrlPath { get; set; } = string.Empty;
    }
    public enum RedesSociais
    {
        NaoContem,
        Linkedin,
        GitHub,
        Instagram,
        Facebook
    }
}