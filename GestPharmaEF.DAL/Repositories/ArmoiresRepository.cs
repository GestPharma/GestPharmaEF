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
        public ArmoireRepository() : base()
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
            // ArmoireEntity Me = _db.Armoires.Find(Armoire.ArmoID)!;
            try
                {
                ArmoireEntity Me = ArmoireMappers.ToEntity(Armoire);
                if (_db.Entry<ArmoireEntity>(Me).State == EntityState.Detached)
                    {
                    _db.Entry<ArmoireEntity>(Me).State = EntityState.Modified;
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
