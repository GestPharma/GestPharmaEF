using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.WebApi.Models
{
    public class J_Armoires : IArmoires
    {
        public long ArmoID { get; set; } = long.MinValue;
        public string ArmoName { get; set; } = string.Empty;
        public string ArmoPatient { get; set; } = string.Empty;
    }
}
