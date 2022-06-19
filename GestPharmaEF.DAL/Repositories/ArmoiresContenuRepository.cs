using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL.Repositories.Abstracts;
using GestPharmaEF.DAL.Repositories.Interface;
using GestPharmaEF.DAL.Repositories.Mappers;
using GestPharmaEF.Models.Concretes;

using Microsoft.EntityFrameworkCore;

namespace GestPharmaEF.DAL.Repositories
{
    public class ArmoiresContenuRepository : BaseRepository<ArmoiresContenu>, IArmoiresContenuRepository
    {
        public ArmoiresContenuRepository(BDPMContext context) : base(context)
        {
        }

        public override ArmoiresContenu GetOne(long id)
        {
            return _db.ArmoiresStocks.Find(id)!.ToModel();
        }
        public override IEnumerable<ArmoiresContenu> GetOne2(long id)
        {
            yield return _db.ArmoiresStocks.Find(id)!.ToModel();
        }
        public IEnumerable<ArmoiresContenu> GetAll(int limit, int offset)
        {
            return _db.ArmoiresStocks.Skip(offset).Take(limit).Select(m => m.ToModel());
        }
        public override IEnumerable<ArmoiresContenu> GetAll()
        {
            return _db.ArmoiresStocks.Select(m => m.ToModel());
        }

        public override bool Add(ArmoiresContenu ArmoiresContenu)
        {
            ArmoiresStockEntity toInsert = ArmoiresContenu.ToEntity();
            _db.ArmoiresStocks.Add(toInsert);

            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                _db.ArmoiresStocks.Remove(toInsert);
                return false;
            }
        }

        public override bool Update(ArmoiresContenu ArmoiresContenu)
        {
            ArmoiresStockEntity toUpdate = _db.ArmoiresStocks.Find(ArmoiresContenu.ACarmoireId)!;
            toUpdate.Armoireid = ArmoiresContenu.ACarmoireId;
            _db.ArmoiresStocks.Remove(_db.ArmoiresStocks.Find(ArmoiresContenu.ACarmoireId)!);
            toUpdate = ArmoiresContenu.ToEntity();
            _db.ArmoiresStocks.Add(toUpdate);

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
                _db.ArmoiresStocks.Remove(_db.ArmoiresStocks.Find(id)!);
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

