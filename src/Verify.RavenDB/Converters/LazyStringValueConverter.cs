using Newtonsoft.Json;
using Sparrow.Json;

class LazyStringValueConverter :
    WriteOnlyJsonConverter<LazyStringValue>
{
    public override void Write(VerifyJsonWriter writer, LazyStringValue value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, (string) value);
    }
}