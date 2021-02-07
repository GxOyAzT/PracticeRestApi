using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiClient
{
    public class PatchJsonList
    {
        public PatchJsonList(List<PatchJson> patchJsons)
        {
            PatchJsons = patchJsons;
        }

        List<PatchJson> PatchJsons;

        public string SerializeObjectToJsonFormat()
        {
            return JsonConvert.SerializeObject(PatchJsons);
        }
    }
}
