using Ethik.Utility.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Models;

public class Inventory : IBaseEntity
{
    public string Id { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public bool IsDeleted { get; set; }

    public int ProductId { get; set; }
    public string BatchNumber { get; set; } = "Unknown";
    public DateTime ManufacturingDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; } = "Unknown";
}
