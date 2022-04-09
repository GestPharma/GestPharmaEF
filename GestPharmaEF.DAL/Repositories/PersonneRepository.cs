using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;
using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.DAL.Repositories
{
    public class PersonneRepository : BaseRepository<Personnes>, IPersonneRepository
    {
        public PersonneRepository() : base()
        {
        }
        public override Personnes GetOne(long id)
        {
            return _db.Personnes.Find(id)!.ToModel();
        }
        public override IEnumerable<Personnes> GetOne2(long id)
        {
            yield return _db.Personnes.Find(id)!.ToModel();
        }
        public override IEnumerable<Personnes> GetAll()
        {
            return _db.Personnes.Select(m => m.ToModel());
        }
        public override bool Add(Personnes Personne)
        {
            RoleRepository rR = new();
            PersonneEntity toInsert = Personne.ToEntity();
            toInsert.Roles = new();
            toInsert.Roles = rR.GetOne(toInsert.CurrentRoleId ?? 2).ToEntity();
            _db.Personnes.Add(toInsert);
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                _db.Personnes.Remove(toInsert);
                return false;
            }
        }
        public override bool Update(Personnes Personne)
        {
            // PersonneEntity Me = _db.Personnes.Find(Personne.PersonneId)!;
            try
            {
                PersonneEntity Me = PersonneMappers.ToEntity(Personne);
                if (_db.Entry<PersonneEntity>(Me).State == EntityState.Detached)
                {
                    _db.Entry<PersonneEntity>(Me).State = EntityState.Modified;
                }
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public override bool Delete(long id)
        {
            try
            {
                _db.Personnes.Remove(_db.Personnes.Find(id)!);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;

            }
        }

        public bool GetUser(string email, string password)
        {
            // https://codepedia.info/jwt-authentication-in-aspnet-core-web-api-token
            foreach (Personnes pers in this.GetAll().ToList())
            {
                if (pers.paswword == password && pers.email == email && pers.isactive) return true;
            }
            return false;
        }
    }
}
