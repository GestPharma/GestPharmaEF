using GestPharmaEF.DAL.Entities;
using GestPharmaEF.Models.Concretes;

namespace GestPharmaEF.DAL.Repositories.Mappers
{
    public static class RoleMapper
    {
        public static Roles ToModel(this RoleEntity Entity)
        {
            Roles Role = new(Entity.Name);
            Role.Id = Entity.Id;
            Role.Name = Entity.Name ?? "";
            return Role;
        }

        public static RoleEntity ToEntity(this Roles Model)
        {
            return new RoleEntity()
            {
                Id = Model.Id,
                Name = Model.Name,
            };
        }
    }
}

