using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

public static class JsonExtensions
{
//using Newtonsoft.Json; https://gist.github.com/PaulGreenwell/6695131
//using Newtonsoft.Json.Converters    
    //public static string ToJson(this object entity)
    //{
    //    var serializer = new JsonSerializer();
    //    serializer.Converters.Add(new StringEnumConverter());
    //    using (var writer = new StringWriter())
    //    {
    //        serializer.Serialize(writer, entity);
    //        return writer.ToString();
    //    }
    //}

    // http://msdn.microsoft.com/ru-ru/library/system.runtime.serialization.json.datacontractjsonserializer(v=vs.110).aspx 
    // http://extensionmethod.net/csharp/t/tojson
    public static string ToJson<T>(this T item, System.Text.Encoding encoding = null, System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = null)
    {
        encoding = encoding ?? Encoding.UTF8;
        //  encoding = encoding ?? Encoding.Default;
        serializer = serializer ?? new DataContractJsonSerializer(typeof(T));

        using (var stream = new System.IO.MemoryStream())
        {
            serializer.WriteObject(stream, item);
            var json = encoding.GetString((stream.ToArray()));

            return json;
        }
    }
}