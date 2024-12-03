using Ethik.Utility.Data.Repository;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Interfaces;

public interface IFoodProductRepository : IBaseRepository<FoodProduct>
{
}