using GestPharmaEF.Models.Interfaces;
namespace GestPharmaEF.WebApi.Models
{
    public class J_Roles : IRoles
    {
        public long Id { get; set; } = long.MinValue;
        public string Name { get; set; } = string.Empty;
    }
}
