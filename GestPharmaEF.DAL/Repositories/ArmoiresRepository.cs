using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;

using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.DAL.Repositories
    {
    public class ArmoireRepository : BaseRepository<Armoires>, IArmoiresRepository
        {
        public ArmoireRepository(BDPMContext context) : base(context)
        {
        }

        public override Armoires GetOne(long id)
        {
            return _db.Armoires.Find(id)!.ToModel();
        }
        public override IEnumerable<Armoires> GetOne2(long id)
            {
            yield return _db.Armoires.Find(id)!.ToModel();
            }
        public IEnumerable<Armoires> GetAll(int limit, int offset)
        {
            return _db.Armoires.Skip(offset).Take(limit).Select(m => m.ToModel());
        }
        public override IEnumerable<Armoires> GetAll()
            {
            return _db.Armoires.Select(m => m.ToModel());
            }

        public override bool Add(Armoires Armoire)
            {
            ArmoireEntity toInsert = Armoire.ToEntity();
            _db.Armoires.Add(toInsert);

            try
                {
                _db.SaveChanges();
                return true;
                }
            catch (DbUpdateException)
                {
                _db.Armoires.Remove(toInsert);
                return false;
                }
            }

        public override bool Update(Armoires Armoire)
        {
            ArmoireEntity toUpdate = _db.Armoires.Find(Armoire.ArmoID)!;
            toUpdate.Id = Armoire.ArmoID;
            _db.Armoires.Remove(_db.Armoires.Find(Armoire.ArmoID)!);
            toUpdate = Armoire.ToEntity();
            _db.Armoires.Add(toUpdate);

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
                _db.Armoires.Remove(_db.Armoires.Find(id)!);
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
