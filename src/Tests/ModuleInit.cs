public static class ModuleInit
{
    #region enable

    [ModuleInitializer]
    public static void Init()
    {
        VerifyRavenDB.Enable();

        #endregion

        VerifyDiffPlex.Initialize();
    }
}