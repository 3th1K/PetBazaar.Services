namespace PetBazaar.Shared.Base.Queries;

public abstract class BasePagedQuery
{
    public bool IncludeDeleted { get; set; } = false;
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public bool? Ascending { get; set; }

    protected BasePagedQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
    {
        IncludeDeleted = includeDeleted;
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = orderBy;
        Ascending = ascending;
    }
}

