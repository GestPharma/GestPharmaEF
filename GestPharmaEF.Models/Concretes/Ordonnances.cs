using GestPharmaEF.Models.Interfaces;

namespace GestPharmaEF.Models.Concretes
    {
    /// <summary>
    /// </summary>
    public class Ordonnances : IOrdonnances
        {
        public Ordonnances(long Id, string Code_barre, DateTime Date_creer, DateTime Date_expire, long Medecinid, long Pharmacieid)
            {
            OrdonnanceId = Id;
            OrdonnanceCode_barre = Code_barre;
            OrdonnanceDate_creer = Date_creer;
            OrdonnanceDate_expire = Date_expire;
            OrdonnanceMedecinid = Medecinid;
            OrdonnancePharmacieid = Pharmacieid;
            }
        #region Fields
        public long OrdonnanceId { get; set; } = long.MinValue;
        public string OrdonnanceCode_barre { get; set; } = string.Empty;
        public DateTime OrdonnanceDate_creer { get; set; } = DateTime.MinValue;
        public DateTime OrdonnanceDate_expire { get; set; } = DateTime.MinValue;
        public long OrdonnanceMedecinid { get; set; } = long.MinValue;
        public long OrdonnancePharmacieid{ get; set; } = long.MinValue;

        #endregion // Fields
        }
    }
