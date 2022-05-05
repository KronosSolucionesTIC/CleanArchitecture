﻿namespace CleanArchitecth.Domain.Entities;

/// <summary>
/// Entidad de cliente
/// </summary>
public class Cliente
{
    #region Propiedades
    /// <summary>
    /// Id del cliente
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Nombres del cliente
    /// </summary>
    public string Nombres { get; set; }
    /// <summary>
    /// Apellidos del cliente
    /// </summary>
    public string Apellidos { get; set; }
    /// <summary>
    /// Documento del cliente
    /// </summary>
    public int Documento { get; set; }
    /// <summary>
    /// Tipo de documento
    /// </summary>
    //public TipoDocumento TipoDoc { get; set; }
    #endregion
}
