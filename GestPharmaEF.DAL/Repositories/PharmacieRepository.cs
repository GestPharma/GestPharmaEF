using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;
using Microsoft.EntityFrameworkCore;


namespace GestPharmaEF.DAL.Repositories
    {
    public class PharmacieRepository : BaseRepository<Pharmacies>, IPharmacieRepository
        {
        public PharmacieRepository(BDPMContext context) : base(context)
        {
        }

        public override bool Add(Pharmacies Pharmacie)
            {
            PharmacyEntity toInsert = Pharmacie.ToEntity();
            _db.Pharmacies.Add(toInsert);

            try
                {
                _db.SaveChanges();
                return true;
                }
            catch (DbUpdateException)
                {
                _db.Pharmacies.Remove(toInsert);
                return false;
                }
            }

        public override bool Delete(long id)
            {
            try
                {
                _db.Pharmacies.Remove(_db.Pharmacies.Find(id)!);
                _db.SaveChanges();
                return true;
                }
            catch (DbUpdateException)
                {
                return false;

                }
            }
        public IEnumerable<Pharmacies> GetAll(int limit, int offset)
        {
            return _db.Pharmacies.Skip(offset).Take(limit).Select(m => m.ToModel());
        }

        public override IEnumerable<Pharmacies> GetAll()
            {
            return _db.Pharmacies.Select(m => m.ToModel());
            }

        public override Pharmacies GetOne(long id)
            {
            return _db.Pharmacies.Find(id)!.ToModel();
            }
        public override IEnumerable<Pharmacies> GetOne2(long id)
        {
            yield return _db.Pharmacies.Find(id)!.ToModel();
        }

        public override bool Update(Pharmacies Pharmacie)
        {
            PharmacyEntity toUpdate = _db.Pharmacies.Find(Pharmacie.PharmacieId)!;
            toUpdate.Id = Pharmacie.PharmacieId;
            _db.Pharmacies.Remove(_db.Pharmacies.Find(Pharmacie.PharmacieId)!);
            toUpdate = Pharmacie.ToEntity();
            _db.Pharmacies.Add(toUpdate);

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
    }
}
