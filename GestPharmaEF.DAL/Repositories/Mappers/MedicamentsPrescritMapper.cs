using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
    {
    public static class MedicamentsPrescritMappers
        {
        public static MedicamentsPrescrits ToModel(this MedicamentsPrescritEntity Entity)
            {
            MedicamentsPrescrits MedicamentsPrescrit = new(Entity.Ordonnanceid,
                                    Entity.Medicamentid,
                                    Entity.Quantite,
                                    Entity.Prise);
            return MedicamentsPrescrit;
            }

        public static MedicamentsPrescritEntity ToEntity(this MedicamentsPrescrits Model)
            {
            return new MedicamentsPrescritEntity()
                {
                Ordonnanceid = Model.MPOrdonnanceId,
                Medicamentid = Model.MPMedicamentId,
                Quantite = Model.MPQuantite,
                Prise = Model.MPPrise
                };
            }
        }
    }
