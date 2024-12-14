using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.Features.Common.Dtos;

public abstract class AddProductResponse
{
    public string Id { get; set; } = null!;
}