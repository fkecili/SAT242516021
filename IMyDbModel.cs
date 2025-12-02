using System.Collections.Generic;

namespace MyDbModels
{
    public interface IMyDbModel<T> where T : class, new()
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string OrderBy { get; set; }
        IList<T>? Items { get; set; }
    }
}
