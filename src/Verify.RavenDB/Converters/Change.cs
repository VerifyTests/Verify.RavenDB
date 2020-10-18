﻿using Raven.Client.Documents.Session;

class Change
{
    public DocumentsChanges.ChangeType Type;
    public string? FieldName;
    public object? NewValue;
    public object? OldValue;
}