namespace Blogy.Business.Services.GenericService;

public interface IGenericService<TResult,TUpdate,TCreate>
{
    Task<List<TResult>> GetAllAsync();
    Task<TUpdate?> GetByIdAsync(int id);
    Task CreateAsync(TCreate createDto);
    Task UpdateAsync(TUpdate updateDto);
    Task DeleteAsync(int id);
}
