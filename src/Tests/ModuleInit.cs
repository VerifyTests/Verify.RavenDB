public static class ModuleInit
{
    #region enable

    [ModuleInitializer]
    public static void Init() =>
        VerifyRavenDB.Enable();

    #endregion

    [ModuleInitializer]
    public static void InitOther() =>
        VerifyDiffPlex.Initialize();
}