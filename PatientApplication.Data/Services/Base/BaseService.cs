using PatientApplication.Data.Interfaces.Base;

namespace PatientApplication.Data.Services.Base
{
    public class BaseService<T, TId> : IBaseService<T, TId> where T : class
    {
        private readonly PatientContext _context;

        public BaseService(PatientContext context)
        {
            _context = context;
        }
        public T? GetById(TId id)
            => _context.Set<T>().Find(id);

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public bool Delete(TId id)
        {
            var entity = GetById(id);

            if (entity == null)
                return false;

            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}
