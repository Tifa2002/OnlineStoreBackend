namespace OnlineStore.Application.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private OnlineStoreDbContext _context;
        
        public Repository(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var OldEntity=GetById(id);
            _context.Remove(OldEntity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
