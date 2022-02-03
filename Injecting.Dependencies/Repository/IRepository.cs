namespace Injecting.Dependencies.Repository;

public interface IRepository<T>
{
    public void Insert(T item);

    public void Delete(T item);

    public IEnumerable<T> GetBy(Func<T, bool> predicate);
}