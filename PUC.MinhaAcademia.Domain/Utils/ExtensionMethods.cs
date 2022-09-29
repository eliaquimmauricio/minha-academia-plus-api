using Microsoft.AspNetCore.Http;

namespace PUC.MinhaAcademiaPlus.Domain.Utils
{
    public static class ExtensionMethods
    {
        public static bool In<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }

        public static bool In<T>(this T item, List<T> list)
        {
            return list.Contains(item);
        }

        public static T? GetClaim<T>(this IHttpContextAccessor obj, string key)
        {
            try
            {
                string valor = obj.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type.Contains(key))?.Value ?? string.Empty;

                return (T)Convert.ChangeType(valor, typeof(T));
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
