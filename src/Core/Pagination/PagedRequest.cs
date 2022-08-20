using System.ComponentModel.DataAnnotations;

namespace Core.Pagination;

public class PagedRequest<T> where T : new()
{
    public T Filters { get; }

    [Required] public int Page { get; set; }

    [Required] public int PageSize { get; set; }

    public PagedRequest()
    {
        Filters = new T();
    }
}