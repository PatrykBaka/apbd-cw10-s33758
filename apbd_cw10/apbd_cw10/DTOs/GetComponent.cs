namespace apbd_cw10.DTOs;

public class GetComponent
{
    
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public GetComponentManufacturer Manufacturer { get; set; } = null!;
    public GetComponentType Type { get; set; } = null!;

}