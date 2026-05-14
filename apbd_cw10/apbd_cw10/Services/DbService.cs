using apbd_cw10.Data;
using apbd_cw10.DTOs;
using apbd_cw10.Entities;
using apbd_cw10.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw10.Services;

public class DbService : IDbService
{
    
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetPC>> GetPCAsync()
    {

        return await _dbContext.PCs.Select(p => new GetPC
        {
            Id = p.Id,
            Name = p.Name,
            Weight =  p.Weight,
            Warranty = p.Warranty,
            CreatedAt = p.CreatedAt,
            Stock = p.Stock
        }).ToListAsync();
    }

    public async Task<GetPCbyId> GetPCbyIdAsync(int id)
    {
        var result = await _dbContext.PCs.Where(p => p.Id == id).Select(p => new GetPCbyId
        {
            Id = p.Id,
            Name = p.Name,
            Weight =  p.Weight,
            Warranty = p.Warranty,
            CreatedAt = p.CreatedAt,
            Stock = p.Stock,
            PcComponents = p.PCComponents.Select(c => new GetPCComponent
            {
                Amount = c.Amount,
                Component = new GetComponent
                {
                    Code = c.Components.Code,
                    Name = c.Components.Name,
                    Description = c.Components.Description,
                    Manufacturer = new GetComponentManufacturer
                    {
                        Id = c.Components.ComponentManufacturers.Id,
                        Abbreviation = c.Components.ComponentManufacturers.Abbrevation,
                        FullName = c.Components.ComponentManufacturers.FullName,
                        FoundationDate = c.Components.ComponentManufacturers.FoundationDate
                    },
                    Type = new GetComponentType
                    {
                        Id = c.Components.ComponentType.Id,
                        Abbreviation = c.Components.ComponentType.Abbrevation,
                        Name = c.Components.ComponentType.Name
                    }
                }
            }).ToList()
        }).FirstOrDefaultAsync();

        if (result == null)
        {
            throw new NotFoundException("PC not found");
        }

        return result;
    }

    public async Task AddPCAsync(AddPC addPC)
    {
        var newPc = new PC
        {
            Name = addPC.Name,
            Warranty = addPC.Warranty,
            Weight = addPC.Weight,
            CreatedAt = addPC.CreatedAt,
            Stock = addPC.Stock,
        };
        
        await _dbContext.PCs.AddAsync(newPc);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePCAsync(int id, UpdatePC updatePC)
    {
        
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null)
        {
            throw new NotFoundException("PC not found");
        }
        
        pc.Name = updatePC.Name;
        pc.Warranty = updatePC.Warranty;
        pc.Weight = updatePC.Weight;
        pc.CreatedAt = updatePC.CreatedAt;
        pc.Stock = updatePC.Stock;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePCAsync(int id)
    {
     
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null)
        {
            throw new NotFoundException("PC not found");
        }
        
        _dbContext.PCs.Remove(pc);
        await _dbContext.SaveChangesAsync();
    }
    
}