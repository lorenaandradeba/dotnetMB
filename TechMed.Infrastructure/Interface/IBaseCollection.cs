namespace TechMed.Infrastructure.Interfaces;
public interface IBaseCollection<T>
{
   int Create(T obj);
   ICollection<T> GeAll();
   T? GetById(int id);
   void Update(int id, T obj);
   void Delete(int id);
}