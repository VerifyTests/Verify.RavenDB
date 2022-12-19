namespace VerifyTests;

public static class VerifyRavenDB
{
    public static void Enable()
    {
        InnerVerifier.ThrowIfVerifyHasBeenRun();
        VerifierSettings
            .AddExtraSettings(_ =>
            {
                var converters = _.Converters;
                converters.Add(new SessionConverter());
                converters.Add(new LazyStringValueConverter());
            });
    }
}