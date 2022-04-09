using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;
using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.DAL.Repositories
    {
    public class OrdonnanceRepository : BaseRepository<Ordonnances>, IOrdonnanceRepository
        {
        public OrdonnanceRepository() : base()
            {
            }

        public override Ordonnances GetOne(long id)
            {
            return _db.Ordonnances.Find(id)!.ToModel();
            }
        public override IEnumerable<Ordonnances> GetOne2(long id)
        {
            yield return _db.Ordonnances.Find(id)!.ToModel();
        }
        public override IEnumerable<Ordonnances> GetAll()
            {
            return _db.Ordonnances.Select(m => m.ToModel());
            }

        public override bool Add(Ordonnances Ordonnance)
            {
            OrdonnanceEntity toInsert = Ordonnance.ToEntity();
            _db.Ordonnances.Add(toInsert);

            try
                {
                _db.SaveChanges();
                return true;
                }
            catch (DbUpdateException)
                {
                _db.Ordonnances.Remove(toInsert);
                return false;
                }
            }

        public override bool Update(Ordonnances Ordonnance)
            {
            // OrdonnanceEntity Me = _db.Ordonnances.Find(Ordonnance.OrdonnanceId)!;
            try
                {
                OrdonnanceEntity Me = OrdonnanceMappers.ToEntity(Ordonnance);
                if (_db.Entry<OrdonnanceEntity>(Me).State == EntityState.Detached)
                    {
                    _db.Entry<OrdonnanceEntity>(Me).State = EntityState.Modified;
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
                _db.Ordonnances.Remove(_db.Ordonnances.Find(id)!);
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
