using apbd_cw10.DTOs;
using apbd_cw10.Entities;
using apbd_cw10.Exceptions;
using apbd_cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw10.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController : ControllerBase
{
    
    private readonly IDbService _dbService;

    public PCsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPCs()
    {
        var result = await _dbService.GetPCAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetPCsById(int id)
    {
        try
        {

            var result = await _dbService.GetPCbyIdAsync(id);
            return Ok(result);

        }
        catch(NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPC(AddPC addPC)
    {
        await _dbService.AddPCAsync(addPC);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePC(int id, UpdatePC updatePC)
    {
        try
        {

            await _dbService.UpdatePCAsync(id, updatePC);
            return NoContent();

        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePC(int id)
    {
        try
        {
            await _dbService.DeletePCAsync(id);
            return NoContent();   
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}