using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
{
    public static class PersonneMappers
    {
        public static Personnes ToModel(this PersonneEntity? Entity)
        {
            Personnes Personne = new(personnesEmail: Entity?.Email ?? string.Empty,
                                        personnesPaswword: Entity?.Password ?? string.Empty,
                                        personnesisactive: Entity?.IsActive ?? false,
                                        personnesCurrentRoles: Entity?.CurrentRoleId ?? 2,
                                        personnesConnectAs: Entity?.ConnectAs ?? string.Empty)
            {
                Id = Entity?.Id ?? 0
            };
            return Personne;
        }

        public static PersonneEntity ToEntity(this Personnes Model)
        {
            return new PersonneEntity()
            {
                Id = Model.Id,
                Email = Model.Email,
                Password = Model.Paswword,
                IsActive = Model.Isactive,
                ConnectAs = Model.Connectas,
                CurrentRoleId = Model.Currentrole
            };
        }

    }
}
