using System;
using System.ComponentModel.DataAnnotations;

public class Personal
{
    [Key]
    public int NumeroDocumento { get; set; }

    public string Nombres { get; set; }
    public string Apellidos { get; set; }

    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaIngreso { get; set; }

    public int CodigoCargo { get; set; }

    public Cargo Cargo { get; set; }

    // Propiedad calculada para la edad
    public int Edad => DateTime.Now.Year - FechaNacimiento.Year - (DateTime.Now.DayOfYear < FechaNacimiento.DayOfYear ? 1 : 0);
}
