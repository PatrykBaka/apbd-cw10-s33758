namespace apbd_cw10.DTOs;

public class GetComponentManufacturer
{
    
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateOnly FoundationDate { get; set; }
    
}