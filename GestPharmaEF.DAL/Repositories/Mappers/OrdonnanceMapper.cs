using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
    {
    public static class OrdonnanceMappers
        {
        public static Ordonnances ToModel(this OrdonnanceEntity Entity)
            {
            Ordonnances Ordonnance = new(Entity.Id,
                                    Entity.Codebarre ?? "",
                                    Entity.Datecree,
                                    Entity.Dateexpire,
                                    Entity.Medecinid,
                                    Entity.Pharmacieid,
                                    Entity.Patientid)
                                    ;
            return Ordonnance;
            }

        public static OrdonnanceEntity ToEntity(this Ordonnances Model)
            {
            return new OrdonnanceEntity()
                {
                Id = Model.OrdonnanceId,
                Codebarre = Model.OrdonnanceCode_barre,
                Datecree = Model.OrdonnanceDate_creer,
                Dateexpire = Model.OrdonnanceDate_expire,
                Medecinid = Model.OrdonnanceMedecinid,
                Pharmacieid = Model.OrdonnancePharmacieid,
                Patientid = Model.OrdonnancePatient
                };
            }
        }
    }

