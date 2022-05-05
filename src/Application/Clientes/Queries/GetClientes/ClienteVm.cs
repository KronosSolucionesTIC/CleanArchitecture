namespace CleanArchitecth.Application.Clientes.Queries.GetClientes;
/// <summary>
/// Vm de cliente
/// </summary>
public class ClienteVm
{
    public IList<ClienteDto> ListClientes { get; set; } = new List<ClienteDto>();
}

