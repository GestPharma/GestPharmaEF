using GestPharmaEF.Models.Interfaces;
namespace GestPharmaEF.WebApi.Models
{
    public class J_Personnes : IPersonnes
    {
        public long Id { get; set; } = long.MinValue;
        public string email { get; set; } = string.Empty;
        public string paswword { get; set; } = string.Empty;
        public bool isactive { get; set; } = false;
        public long currentrole { get; set; } = 2;
        public string connectAs { get; set; } = string.Empty;

    }
}
