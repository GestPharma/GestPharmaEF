using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;
using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.DAL.Repositories
{
    public class MedecinRepository : BaseRepository<Medecins>, IMedecinRepository
    {
        public override Medecins GetOne(long id)
        {
            return _db.Medecins.Find(id)!.ToModel();
        }
        public override IEnumerable<Medecins> GetOne2(long id)
        {
            yield return _db.Medecins.Find(id)!.ToModel();
        }
        public override IEnumerable<Medecins> GetAll()
        {
            return _db.Medecins.Select(m => m.ToModel());
        }

        public override bool Add(Medecins Medecin)
        {
            MedecinEntity toInsert = Medecin.ToEntity();
            _db.Medecins.Add(toInsert);

            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                _db.Medecins.Remove(toInsert);
                return false;
            }
        }

        public override bool Update(Medecins Medecin)
        {
            // MedecinEntity Me = _db.Medecins.Find(Medecin.MedecinId)!;
            try
            {
                MedecinEntity Me = MedecinMappers.ToEntity(Medecin);
                if ( _db.Entry<MedecinEntity>(Me).State == EntityState.Detached)
                {
                    _db.Entry<MedecinEntity>(Me).State = EntityState.Modified;
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
                _db.Medecins.Remove(_db.Medecins.Find(id)!);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
                
            }
        }
    }
}
