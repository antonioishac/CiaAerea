namespace CiaAerea.ViewModels;

public class AdicionarAeronaveViewModel
{
    public AdicionarAeronaveViewModel(string fabricante, string modelo, string codigo)
    {
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }

    /// <summary>
    /// Nome do fabricante da Aeronave.
    /// </summary>
    /// <example>Boeing</example>
    public string Fabricante { get; set; }
    
    /// <summary>
    /// Nome do modelo da Aeronave.
    /// </summary>
    /// <example>437</example>
    public string Modelo { get; set; }
    
    /// <summary>
    /// Código da Aeronave
    /// </summary>
    /// <example>B-001</example>
    public string Codigo { get; set; }
}