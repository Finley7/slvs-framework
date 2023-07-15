namespace SLVS.DTO;
public class FormModelError
{
    public string Field { get; set; }
    public List<string> Messages { get; } = new();
}