using SmartGarage.Service.QueryObjects;
using System.Collections.Generic;

namespace SmartGarage.Service.Helpers
{
    public class Pager<T>
    {
        public Pager(List<T> itemsColection, PaginationQueryObject pagination)
        {
            this.ItemsColection = itemsColection;
            this.ItemsOnPage = itemsColection.Count;
            this.Page = pagination.Page;
        }
        public int Count { get; set; }

        public int Page { get; set; }

        public int ItemsOnPage { get; set; }

        public List<T> ItemsColection { get; set; }
    }
}
