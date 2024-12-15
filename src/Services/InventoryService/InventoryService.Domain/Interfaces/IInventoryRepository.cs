using Ethik.Utility.Data.Repository;
using InventoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Interfaces;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
}
