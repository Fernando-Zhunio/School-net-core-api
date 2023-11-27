namespace School.Filters
{
    public class PaginationFilter
    {
        public int Page {  get; set; }
        public int PageSize { get; set; }
        //public PaginationFilter(int page,  int pageSize)
        //{
        //    this.Page = page < 1 ? 1 : page;
        //    this.PageSize = pageSize;
        //}

        public PaginationFilter() {
            this.Page = 1;
            this.PageSize = 10;
        }
    }
}
