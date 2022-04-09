using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
    {
    public static class MedicamentMappers
        {
        public static Medicaments ToModel(this MedicamentEntity Entity)
            {
            Medicaments Medicament = new(Entity.Id, Entity.Nom ?? "");
            Medicament.MedicamentId = Entity.Id;
            return Medicament;
            }

        public static MedicamentEntity ToEntity(this Medicaments Model)
            {
            return new MedicamentEntity()
                {
                Id = Model.MedicamentId,
                Nom = Model.MedicamentNom
                };
            }
        }
    }
