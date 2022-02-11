namespace CleanArchitecth.Application.Compras.Queries.GetCompras;
/// <summary>
/// Vm de compras
/// </summary>
public class ComprasVm
{
    /// <summary>
    /// Lista de tipo ComprasDto
    /// </summary>
    public IList<ComprasDto> ListCompras { get; set; } = new List<ComprasDto>();
}
