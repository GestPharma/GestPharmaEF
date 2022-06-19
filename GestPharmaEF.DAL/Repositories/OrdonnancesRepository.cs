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
        public OrdonnanceRepository(BDPMContext context) : base(context)
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
        public IEnumerable<Ordonnances> GetAll(int limit, int offset)
        {
            return _db.Ordonnances.Skip(offset).Take(limit).Select(m => m.ToModel());
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
            OrdonnanceEntity toUpdate = _db.Ordonnances.Find(Ordonnance.OrdonnanceId)!;
            toUpdate.Id = Ordonnance.OrdonnanceId;
            _db.Ordonnances.Remove(_db.Ordonnances.Find(Ordonnance.OrdonnanceId)!);
            toUpdate = Ordonnance.ToEntity();
            _db.Ordonnances.Add(toUpdate);

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
