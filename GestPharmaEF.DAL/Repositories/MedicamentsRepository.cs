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
        public MedicamentRepository(BDPMContext context) : base(context)
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
        public IEnumerable<Medicaments> GetAll(int limit, int offset)
        {
            return _db.Medicaments.Skip(offset).Take(limit).Select(m => m.ToModel());
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
            MedicamentEntity toUpdate = _db.Medicaments.Find(Medicament.MedicamentId)!;
            toUpdate.Id = Medicament.MedicamentId;
            _db.Medicaments.Remove(_db.Medicaments.Find(Medicament.MedicamentId)!);
            toUpdate = Medicament.ToEntity();
            _db.Medicaments.Add(toUpdate);

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
