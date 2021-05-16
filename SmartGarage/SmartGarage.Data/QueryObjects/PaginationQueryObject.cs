using System;
using System.Collections.Generic;
using System.Text;

namespace SmartGarage.Data.QueryObjects
{
    public class PaginationQueryObject
    {
        public PaginationQueryObject()
        {
            this.Page = 1;
            this.ItemsOnPage = 5;
        }

        public PaginationQueryObject(int page, int itemsOnPage)
        {
            this.Page = page;
            this.ItemsOnPage = itemsOnPage;
        }

        public int Page { get; set; }

        public int ItemsOnPage { get; set; }
    }
}
