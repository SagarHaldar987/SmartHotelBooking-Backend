namespace SmartHotelBooking.Helpers
{
    public static class PaginationHelper
    {
        public static int GetTotalPages(int totalItems, int pageSize)
        {
            if (pageSize <= 0) throw new ArgumentException("PageSize must be greater than zero.");
            return (int)Math.Ceiling(totalItems / (double)pageSize);
        }

        public static int GetSkipCount(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            return (pageNumber - 1) * pageSize;
        }
    }
}
