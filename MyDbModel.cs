using System.Collections.Generic;

namespace MyDbModels
{
    public class MyDbModel<T> : IMyDbModel<T> where T : class, new()
    {
        public MyDbModel(int page, int size, string orderBy)
        {
            PageNumber = page;
            PageSize = size;
            OrderBy = orderBy;
            Items = new List<T>();
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public IList<T>? Items { get; set; }
    }
}
