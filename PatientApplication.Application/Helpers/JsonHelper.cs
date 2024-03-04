using System.Text.Json;

namespace PatientApplication.Data.Helpers
{
    public class JsonHelper
    {
        public static string ConvertToJson<T>(T entity)
            => JsonSerializer.Serialize(entity);

        public static string ConvertToJson<T>(IEnumerable<T> entities)
            => entities.Aggregate(string.Empty, (current, entity) => current + JsonSerializer.Serialize(entity));
    }
}
