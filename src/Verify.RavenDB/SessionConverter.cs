using Newtonsoft.Json;
using Raven.Client.Documents.Session;
using VerifyTests;

class SessionConverter :
    WriteOnlyJsonConverter<IDocumentSession>
{
    public override void WriteJson(JsonWriter writer, IDocumentSession? session, JsonSerializer serializer)
    {
        if (session == null)
        {
            return;
        }

        var changed = session.Advanced.WhatChanged();
        if (changed.Count == 0)
        {
            return;
        }
        //writer.WriteStartObject();
        //writer.WritePropertyName("changed");
        serializer.Serialize(writer, changed);
        //writer.WriteEndObject();
    }
}