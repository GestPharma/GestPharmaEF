using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
    {
    public static class ArmoireMappers
        {
        public static Armoires ToModel(this ArmoireEntity Entity)
            {
            Armoires Armoire = new(Entity.Id, Entity.Nom?? "", Entity.Patient?? "");
            Armoire.ArmoID = Entity.Id;
            Armoire.ArmoName = Entity.Nom??"";
            return Armoire;
            }

        public static ArmoireEntity ToEntity(this Armoires Model)
            {
            return new ArmoireEntity()
                {
                Id = Model.ArmoID,
                Nom = Model.ArmoName,
                Patient = Model.ArmoPatient,
                };
            }
        }
    }
