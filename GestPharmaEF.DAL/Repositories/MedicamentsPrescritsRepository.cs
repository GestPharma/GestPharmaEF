using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;

using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.DAL.Repositories
    {
    public class MedicamentsPrescritRepository : BaseRepository<MedicamentsPrescrits>, IMedicamentsPrescritsRepository
        {
        public MedicamentsPrescritRepository() : base()
            {
            }
        public override MedicamentsPrescrits GetOne(long id)
        {
            return _db.MedicamentsPrescrits.Find(id)!.ToModel();
        }
        public override IEnumerable<MedicamentsPrescrits> GetOne2(long id)
            {
            yield return _db.MedicamentsPrescrits.Find(id)!.ToModel();
            }
        public override IEnumerable<MedicamentsPrescrits> GetAll()
            {
            return _db.MedicamentsPrescrits.Select(m => m.ToModel());
            }

        public override bool Add(MedicamentsPrescrits MedicamentsPrescrit)
            {
            MedicamentsPrescritEntity toInsert = MedicamentsPrescrit.ToEntity();
            _db.MedicamentsPrescrits.Add(toInsert);

            try
                {
                _db.SaveChanges();
                return true;
                }
            catch (DbUpdateException)
                {
                _db.MedicamentsPrescrits.Remove(toInsert);
                return false;
                }
            }

        public override bool Update(MedicamentsPrescrits MedicamentsPrescrit)
            {
            // MedicamentsPrescritEntity Me = _db.MedicamentsPrescrits.Find(MedicamentsPrescrit.MPMedicamentId)!;
            try
                {
                MedicamentsPrescritEntity Me = MedicamentsPrescritMappers.ToEntity(MedicamentsPrescrit);
                if (_db.Entry<MedicamentsPrescritEntity>(Me).State == EntityState.Detached)
                    {
                    _db.Entry<MedicamentsPrescritEntity>(Me).State = EntityState.Modified;
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
                _db.MedicamentsPrescrits.Remove(_db.MedicamentsPrescrits.Find(id)!);
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