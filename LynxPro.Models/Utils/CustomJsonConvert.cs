using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace LynxPro.Models.Utils
{
    public class CustomJsonConvert
    {
        /// <summary>
        /// Convert the object into camel-case JSON string which is formatted based on the parameters.
        /// </summary>
        /// <param name="value">Object to be serialized</param>
        /// <param name="formatting">Default = Indented</param>
        /// <param name="nullValueHandling">Default = Ignore</param>
        /// <returns></returns>
        public static string ToCamelCase(object value, Formatting formatting = Formatting.Indented,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = nullValueHandling,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = formatting
            };

            return JsonConvert.SerializeObject(value, settings);
        }
    }
}
