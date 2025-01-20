namespace PetBazaar.Shared.Base.Queries;

/// <summary>
/// Base class for all paged queries within the application.
/// Encapsulates common properties for pagination, sorting, and inclusion of deleted records.
/// </summary>
public abstract class BasePagedQuery
{
    /// <summary>
    /// Indicates whether deleted records should be included in the query results.
    /// </summary>
    public bool IncludeDeleted { get; set; } = false;

    /// <summary>
    /// Specifies the current page number for pagination.
    /// </summary>
    public int? PageNumber { get; set; }

    /// <summary>
    /// Defines the number of records to be returned per page.
    /// </summary>
    public int? PageSize { get; set; }

    /// <summary>
    /// Specifies the property or column to sort the results by.
    /// </summary>
    public string? OrderBy { get; set; }

    /// <summary>
    /// Indicates the sorting direction (true for ascending, false for descending).
    /// </summary>
    public bool? Ascending { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BasePagedQuery"/> class.
    /// </summary>
    /// <param name="includeDeleted">Indicates whether deleted records should be included.</param>
    /// <param name="pageNumber">Specifies the current page number.</param>
    /// <param name="pageSize">Defines the number of records per page.</param>
    /// <param name="orderBy">Specifies the property to sort by.</param>
    /// <param name="ascending">Indicates the sorting direction.</param>
    protected BasePagedQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
    {
        IncludeDeleted = includeDeleted;
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = orderBy;
        Ascending = ascending;
    }
}