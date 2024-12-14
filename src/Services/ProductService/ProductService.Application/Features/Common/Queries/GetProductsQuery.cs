
namespace ProductService.Application.Features.Common.Queries;

public abstract class GetProductsQuery
{
    public bool IncludeDeleted { get; set; } = false;
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public bool? Ascending { get; set; }
}