using Newtonsoft.Json;

namespace LynxPro.Models.Json
{
    public static class JsonMapper
    {
        public static T Map<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T MapOrDefault<T>(string json) where T : class
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}