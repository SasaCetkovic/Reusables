namespace System
{
	public static class DateTimeExtensions
	{
        private static readonly DateTime _unixStartDateTime = new DateTime(1970, 1, 1);

        public static long ToUnixTimestamp(this DateTime date)
        {
            return Convert.ToInt64(date.Subtract(_unixStartDateTime).TotalSeconds);
        }

        public static long ToUnixTimestamp(this DateTime? date)
        {
            if (!date.HasValue)
            {
                return 0;
            }

            return ToUnixTimestamp(date.Value);
        }
    }
}
