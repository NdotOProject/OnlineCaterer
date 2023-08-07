
namespace OnlineCaterer.Application.Common.Interfaces.Data;

public interface IRespository<TEntity>
    where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(object id);

    TEntity Insert(TEntity entity);

    TEntity Update(TEntity entity);

    TEntity Delete(TEntity entity);

}
