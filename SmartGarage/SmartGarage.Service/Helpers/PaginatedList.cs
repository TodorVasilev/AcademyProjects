using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartGarage.Service.Helpers
{
    public class PaginatedList<T>
    {
        public int Count { get; private set; }

        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        [JsonIgnore]
        public int PageSize { get; private set; }

        public IEnumerable<T> ItemsCollection { get; set; }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageSize = pageSize;
            this.Count = count;
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.ItemsCollection = items;
        }

        [JsonIgnore]
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        [JsonIgnore]
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PaginatedList<T> CreateAsync(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
