namespace PatientApplication.Data.Interfaces.Base
{
    public interface IBaseService<T, TId>
    {
        public void Add(T entity);

        public T? GetById(TId id);

        public void Update(T entity);

        public bool Delete(TId id);
    }
}
