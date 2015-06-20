using System.Text;

namespace Sample.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertToString<T>(this T source)
        {
            var type = typeof(T);
            var sb = new StringBuilder();

            sb.AppendLine(type.FullName);
            foreach (var propertyInfo in type.GetProperties())
            {
                if (propertyInfo.CanRead)
                    sb.AppendFormat("{0}:{1}\n", propertyInfo.Name, propertyInfo.GetValue(source));
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}