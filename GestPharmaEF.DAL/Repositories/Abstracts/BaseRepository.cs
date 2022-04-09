using GestPharmaEF.DAL.Repositories.Interface;

namespace GestPharmaEF.DAL.Repositories.Abstracts
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly BDPMContext _db;
        public BaseRepository()
        {
            _db = new BDPMContext();
        }

        public abstract T GetOne(long id);
        public abstract IEnumerable<T> GetOne2(long id);
        public abstract IEnumerable<T> GetAll();

        public abstract bool Add(T Model);

        public abstract bool Update(T Model);

        public abstract bool Delete(long id);
    }
}
