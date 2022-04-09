using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
    {
    public static class ArmoiresStockMappers
        {
        public static ArmoiresContenu ToModel(this ArmoiresStockEntity Entity)
            {
            ArmoiresContenu ArmoiresStock = new(Entity.Medicamentid ?? "",
                                    Entity.Armoireid??0,
                                    Entity.Ordonnanceid??0,
                                    Entity.Quantite??0,
                                    Entity.Mediid);
            return ArmoiresStock;
            }

        public static ArmoiresStockEntity ToEntity(this ArmoiresContenu Model)
            {
            return new ArmoiresStockEntity()
                {
                Medicamentid = Model.ACmedicamentId,
                Armoireid = Model.ACarmoireId,
                Ordonnanceid = Model.ACordonnanceId,
                Quantite = Model.ACquantite,
                Mediid = Model.ACmediId
                };
            }
        }
    }
