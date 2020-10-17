using System.Threading.Tasks;
using NUnit.Framework;
using Raven.Embedded;
using VerifyNUnit;
using VerifyTests;

[TestFixture]
public class Tests
{
    static EmbeddedServer server;

    static Tests()
    {
        VerifyRavenDB.Enable();
        server = EmbeddedServer.Instance;
        server.StartServer();
    }

    [Test]
    public async Task Empty()
    {

        using var store = await server.GetDocumentStoreAsync("Empty");
        using var session = store.OpenSession();
        await Verifier.Verify(session);
    }

    [Test]
    public async Task WithChanges()
    {
        using var store = await server.GetDocumentStoreAsync("Empty");
        using var session = store.OpenSession();
        session.Store(new Person("John"));
        await Verifier.Verify(session);
    }
}

public record Person(string Name);