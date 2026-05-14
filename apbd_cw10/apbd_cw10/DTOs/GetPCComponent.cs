using apbd_cw10.Entities;

namespace apbd_cw10.DTOs;

public class GetPCComponent
{
    
    public int Amount { get; set; }
    public GetComponent Component { get; set; } = null!;

}