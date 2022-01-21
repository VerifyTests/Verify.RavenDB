using Sparrow.Json;

class LazyStringValueConverter :
    WriteOnlyJsonConverter<LazyStringValue>
{
    public override void Write(VerifyJsonWriter writer, LazyStringValue value)
    {
        writer.Serialize((string) value);
    }
}