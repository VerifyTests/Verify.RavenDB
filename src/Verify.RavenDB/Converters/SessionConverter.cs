using System;
using System.Linq;
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

        serializer.Serialize(writer,
            changed.Select(pair =>
                new DocChanges
                {
                    Key = pair.Key,
                    Changes = pair.Value
                        .Select(
                            change =>
                                BuildChange(change, session, pair.Key)).ToList()
                }));
    }

    static Change BuildChange(DocumentsChanges change, IDocumentSession session, string key)
    {
        var changeType = change.Change;
        if (changeType == DocumentsChanges.ChangeType.DocumentAdded)
        {
            return new Change
            {
                Type = changeType,
                NewValue = session.Load<object>(key)
            };
        }

        return new Change
        {
            Type = changeType,
            FieldName = change.FieldName,
            OldValue = change.FieldOldValue,
            NewValue = change.FieldNewValue
        };
    }
}