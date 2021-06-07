namespace SmartGarage.Service.QueryObjects
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
