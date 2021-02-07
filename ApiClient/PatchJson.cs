using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiClient
{
    public class PatchJson
    {
        public PatchJson(PatchOperation patchOperation, string path, object newValue)
        {
            PatchOperation = patchOperation;
            Path = path;
            NewValue = newValue;
        }

        private PatchOperation PatchOperation { get; }
        private string Path { get; }
        private object NewValue { get; }
        public string op => PatchOperation.ToString();
        public string path => $"/{Path}";
        public object value => NewValue;

        //public string SerializeObjectToJsonFormat()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
    }

    public enum PatchOperation
    {
        add,
        remove,
        replace,
        move,
        copy,
        test
    }
}
