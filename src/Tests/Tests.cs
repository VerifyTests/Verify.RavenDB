using Raven.Embedded;

[TestFixture]
public class Tests
{
    static EmbeddedServer server;

    static Tests()
    {
        #region Enable

        VerifyRavenDB.Enable();

        #endregion

        server = EmbeddedServer.Instance;
        var path = Path.Combine(Path.GetTempPath(), "RavenTestData");
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }

        Directory.CreateDirectory(path);
        server.StartServer(
            new ServerOptions
            {
                DataDirectory = path
            });
    }

    [Test]
    public async Task Added()
    {
        using var store = await server.GetDocumentStoreAsync("Added");
        using var session = store.OpenSession();

        #region Added

        var entity = new Person
        {
            Name = "John"
        };
        session.Store(entity);
        await Verify(session);

        #endregion
    }

    [Test]
    public async Task Updated()
    {
        using var store = await server.GetDocumentStoreAsync("Updated");
        using var session = store.OpenSession();

        #region Updated

        var entity = new Person
        {
            Name = "John"
        };
        session.Store(entity);
        session.SaveChanges();
        entity.Name = "Joe";
        await Verify(session);

        #endregion
    }
}