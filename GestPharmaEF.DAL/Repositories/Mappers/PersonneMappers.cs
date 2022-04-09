using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
{
    public static class PersonneMappers
    {
        public static Personnes ToModel(this PersonneEntity? Entity)
        {
            Personnes Personne = new(Entity.Email??String.Empty, Entity.Password??String.Empty, Entity.IsActive??false, Entity.CurrentRoleId??2);
            Personne.Id = Entity.Id ?? long.MinValue;
            return Personne;
        }

        public static PersonneEntity ToEntity(this Personnes Model)
        {
            return new PersonneEntity()
            {
                Id = Model.Id,
                Email = Model.email,
                Password = Model.paswword,
                IsActive = Model.isactive,
                ConnectAs = Model.connectas,
                CurrentRoleId = Model.currentrole
            };
        }

    }
}
