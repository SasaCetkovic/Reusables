using System.Text;

namespace System
{
	public static class StringExtensions
	{
        public static bool IsASCII(this string value)
        {
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }
    }
}
