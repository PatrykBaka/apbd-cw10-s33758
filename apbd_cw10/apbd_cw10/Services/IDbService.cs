using apbd_cw10.DTOs;

namespace apbd_cw10.Services;

public interface IDbService
{

    Task<IEnumerable<GetPC>> GetPCAsync();
    Task<GetPCbyId> GetPCbyIdAsync(int id);
    Task AddPCAsync(AddPC addPC);
    Task UpdatePCAsync(int Id,UpdatePC updatePC);
    Task DeletePCAsync(int Id);

}