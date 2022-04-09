using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.Models.Concretes
    {
    /// <summary>
    /// </summary>
    public class ArmoiresContenu : IArmoiresContenu
        {
        public ArmoiresContenu(string ACme, long ACar, long ACor, long ACqu, long Medi_Id)
            {
            ACmedicamentId = ACme;
            ACarmoireId = ACar;
            ACordonnanceId = ACor;
            ACquantite = ACqu;
            ACmediId = Medi_Id;
            }
        public string ACmedicamentId { get; set; } = string.Empty;
        public long ACarmoireId { get; set; } = long.MinValue;
        public long ACordonnanceId { get; set; } = long.MinValue;
        public long ACquantite { get; set; } = long.MinValue;
        public long ACmediId { get; set; } = long.MinValue;
        }
    }