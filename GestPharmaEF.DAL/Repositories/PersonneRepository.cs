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
        public PersonneRepository(BDPMContext context) : base(context)
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
            PersonneEntity toInsert = Personne.ToEntity();
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
            PersonneEntity toUpdate = _db.Personnes.Find(Personne.Id)!;
            toUpdate.Id = Personne.Id;
            _db.Personnes.Remove(_db.Personnes.Find(Personne.Id)!);
            toUpdate = Personne.ToEntity();
            _db.Personnes.Add(toUpdate);
            try
            {
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
                if (pers.Paswword == password && pers.Email == email && pers.Isactive) return true;
            }
            return false;
        }
    }
}
