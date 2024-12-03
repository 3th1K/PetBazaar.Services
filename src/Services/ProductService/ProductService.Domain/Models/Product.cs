using Ethik.Utility.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Models;

public abstract class Product : IBaseEntity
{
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public bool? IsDeleted { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string DescriptionShort { get; set; }

    [MaxLength(100)]
    public string DescriptionMedium { get; set; }

    [MaxLength(500)]
    public string DescriptionLarge { get; set; }
}