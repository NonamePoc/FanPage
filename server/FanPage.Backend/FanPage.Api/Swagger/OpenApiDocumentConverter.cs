// using Microsoft.OpenApi.Models;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
//
// public class OpenApiDocumentConverter : JsonConverter<OpenApiDocument>
// {
//     // public override OpenApiDocument ReadJson(JsonReader reader, Type objectType, OpenApiDocument existingValue, bool hasExistingValue, JsonSerializer serializer)
//     // {
//     //     var jObject = JObject.Load(reader);
//     //     var document = new OpenApiDocument();
//     //     serializer.Populate(jObject.CreateReader(), document);
//     //     return document;
//     // }
//     //
//     // public override void WriteJson(JsonWriter writer, OpenApiDocument value, JsonSerializer serializer)
//     // {
//     //     var jObject = JObject.FromObject(value);
//     //     jObject.WriteTo(writer);
//     // }
// }