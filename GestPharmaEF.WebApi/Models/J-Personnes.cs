using GestPharmaEF.Models.Interfaces;
namespace GestPharmaEF.WebApi.Models
{
    public class J_Personnes : IPersonnes
    {
        public long Id { get; set; } = long.MinValue;
        public string Email { get; set; } = string.Empty;
        public string Paswword { get; set; } = string.Empty;
        public bool Isactive { get; set; } = false;
        public long Currentrole { get; set; } = 2;
        public string ConnectAs { get; set; } = string.Empty;

    }
}
