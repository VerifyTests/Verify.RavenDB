using System.Collections.Generic;
using Newtonsoft.Json;
using Sparrow.Json;
using VerifyTests;

class LazyStringValueConverter :
    WriteOnlyJsonConverter<LazyStringValue>
{
    public override void WriteJson(
        JsonWriter writer,
        LazyStringValue? value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (value == null)
        {
            return;
        }

        serializer.Serialize(writer,(string)value);
    }
}