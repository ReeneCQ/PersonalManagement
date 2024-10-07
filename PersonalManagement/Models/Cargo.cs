using System.ComponentModel.DataAnnotations;

public class Cargo
{
    [Key]
    public int CodigoCargo { get; set; }

    public string DescripcionCargo { get; set; }
}
