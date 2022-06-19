using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.Models.Concretes
    {
    /// <summary>
    /// </summary>
    public class Armoires : IArmoires
        {
        public Armoires(long Armo_ID, string Armo_Name, long Armo_Patient)
            {
            ArmoID = Armo_ID;
            ArmoName = Armo_Name;
            ArmoPatient = Armo_Patient;
            }
        public long ArmoID { get; set; } = long.MinValue;
        public string ArmoName { get; set; } = string.Empty;
        public long ArmoPatient { get; set; } = long.MinValue;
    }
    }
