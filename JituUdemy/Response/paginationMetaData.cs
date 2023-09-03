namespace JituUdemy.Response
{
    public class paginationMetaData
    {
        public int PageSize { get; set; }
        public int PageCount { get; set;}
        public int CurrentPage { get; set;}
        public int TotalCount { get; set;}

        public paginationMetaData(int ps, int cp, int tc)
        {
            PageSize = ps;
            CurrentPage = cp;
            TotalCount = tc;
            PageCount = (int)Math.Ceiling((double)tc / (double)ps);
        }
    }
}
