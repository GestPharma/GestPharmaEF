using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;
using Microsoft.EntityFrameworkCore;


namespace GestPharmaEF.DAL.Repositories
    {
    public class PharmacieRepository : BaseRepository<Pharmacies>, IPharmacieRepository
        {
        public PharmacieRepository() : base()
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
            // PharmacyEntity Ph = _db.Pharmacies.Find(Pharmacie.PharmacieId)!;
            try
                {
                PharmacyEntity Ph = PharmacieMapper.ToEntity(Pharmacie);
                if (_db.Entry<PharmacyEntity>(Ph).State == EntityState.Detached)
                    {
                    _db.Entry<PharmacyEntity>(Ph).State = EntityState.Modified;
                    }
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
