using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.WebApi.Models
{
    public class J_ArmoiresContenu : IArmoiresContenu
    {
        public string ACmedicamentId { get; set; } = string.Empty;
        public long ACarmoireId { get; set; } = long.MinValue;
        public long ACordonnanceId { get; set; } = long.MinValue;
        public long ACquantite { get; set; } = long.MinValue;
        public long ACmediId { get; set; } = long.MinValue;
    }
}
