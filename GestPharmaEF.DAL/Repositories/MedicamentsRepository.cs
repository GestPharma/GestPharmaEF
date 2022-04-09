using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;
using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.DAL.Repositories
    {
    public class MedicamentRepository : BaseRepository<Medicaments>, IMedicamentsRepository
        {
        public MedicamentRepository() : base()
            {
            }
        public override Medicaments GetOne(long id)
        {
            return _db.Medicaments.Find(id)!.ToModel();
        }
        public override IEnumerable<Medicaments> GetOne2(long id)
            {
            yield return _db.Medicaments.Find(id)!.ToModel();
            }
        public override IEnumerable<Medicaments> GetAll()
            {
            return _db.Medicaments.Select(m => m.ToModel());
            }

        public override bool Add(Medicaments Medicament)
            {
            MedicamentEntity toInsert = Medicament.ToEntity();
            _db.Medicaments.Add(toInsert);

            try
                {
                _db.SaveChanges();
                return true;
                }
            catch (DbUpdateException)
                {
                _db.Medicaments.Remove(toInsert);
                return false;
                }
            }

        public override bool Update(Medicaments Medicament)
            {
            // MedicamentEntity Me = _db.Medicaments.Find(Medicament.MedicamentId)!;
            try
                {
                MedicamentEntity Me = MedicamentMappers.ToEntity(Medicament);
                if (_db.Entry<MedicamentEntity>(Me).State == EntityState.Detached)
                    {
                    _db.Entry<MedicamentEntity>(Me).State = EntityState.Modified;
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
                _db.Medicaments.Remove(_db.Medicaments.Find(id)!);
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
