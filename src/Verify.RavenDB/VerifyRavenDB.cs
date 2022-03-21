namespace VerifyTests;

public static class VerifyRavenDB
{
    public static void Enable() =>
        VerifierSettings.ModifySerialization(settings =>
        {
            settings.AddExtraSettings(serializerSettings =>
            {
                var converters = serializerSettings.Converters;
                converters.Add(new SessionConverter());
                converters.Add(new LazyStringValueConverter());
            });
        });
}