using Newtonsoft.Json;

namespace PUC.MinhaAcademiaPlus.Domain.Utils
{
    public static class Util
    {
        public static T DesserializarJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível desserializar o JSON corretamente.", ex);
            }
        }

        public static string SerializarJson(object? obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível serializar o JSON corretamente.", ex);
            }
        }
    }
}
