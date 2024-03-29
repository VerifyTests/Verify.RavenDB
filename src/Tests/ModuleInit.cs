﻿public static class ModuleInit
{
    #region enable

    [ModuleInitializer]
    public static void Init() =>
        VerifyRavenDB.Initialize();

    #endregion

    [ModuleInitializer]
    public static void InitOther() =>
        VerifierSettings.InitializePlugins();
}