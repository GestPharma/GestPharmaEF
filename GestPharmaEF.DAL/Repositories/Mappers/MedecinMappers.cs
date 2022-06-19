using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
{
    public static class MedecinMappers  
    {
        public static Medecins ToModel(this MedecinEntity Entity)
        {
            Medecins Medecin = new(Entity.Nom ?? "",
                                    Entity.Inami ?? "",
                                    Entity.Rue ?? "",
                                    Entity.Ville ?? "",
                                    Entity.Telephone ?? "",
                                    Entity.Gsm ?? "",
                                    Entity.Fax ?? "",
                                    Entity.Email ?? "")
            {
                MedecinId = Entity.IdMedecin
            };
            return Medecin;
        }

        public static MedecinEntity ToEntity(this Medecins Model)
        {
            return   new MedecinEntity()
            {
                IdMedecin = Model.MedecinId,
                Nom = Model.MedecinName,
                Inami = Model.MedecinInami,
                Rue = Model.MedecinRue,
                Telephone = Model.MedecinTelephone,
                Gsm = Model.MedecinGsm,
                Fax = Model.MedecinFax,
                Email = Model.MedecinEmail,
                Ville = Model.MedecinVille
                };
        }
    }
}
