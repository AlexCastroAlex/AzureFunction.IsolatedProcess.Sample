using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.EF.UoW.Core.Models;

public class Catalog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CatalogueId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}