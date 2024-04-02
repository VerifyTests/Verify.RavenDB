# <img src="/src/icon.png" height="30px"> Verify.RavenDB

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/3tbsai6lv4d005pg?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-ravendb)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.RavenDB.svg)](https://www.nuget.org/packages/Verify.RavenDB/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [RavenDB](https://ravendb.net/) bits.

**See [Milestones](../../milestones?state=closed) for release notes.**


## NuGet package

https://nuget.org/packages/Verify.RavenDB/


## Enable

Enable VerifyRavenDB once at assembly load time:

<!-- snippet: enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Init() =>
    VerifyRavenDB.Initialize();
```
<sup><a href='/src/Tests/ModuleInit.cs#L3-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Usage

Verifiying an [IDocumentSession](https://ravendb.net/docs/article-page/5.0/Csharp/client-api/session/what-is-a-session-and-how-does-it-work) will result in all pending changes being written to a snapshot.


### Document added

Adding a document to a session:

<!-- snippet: Added -->
<a id='snippet-Added'></a>
```cs
var entity = new Person
{
    Name = "John"
};
session.Store(entity);
await Verify(session);
```
<sup><a href='/src/Tests/Tests.cs#L31-L40' title='Snippet source file'>snippet source</a> | <a href='#snippet-Added' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Will result in the following verified file:

<!-- snippet: Tests.Added.verified.txt -->
<a id='snippet-Tests.Added.verified.txt'></a>
```txt
[
  {
    Key: people/1-A,
    Changes: [
      {
        Type: DocumentAdded,
        NewValue: {
          Name: John
        }
      }
    ]
  }
]
```
<sup><a href='/src/Tests/Tests.Added.verified.txt#L1-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.Added.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Document updated

Updating a document in a session:

<!-- snippet: Updated -->
<a id='snippet-Updated'></a>
```cs
var entity = new Person
{
    Name = "John"
};
session.Store(entity);
session.SaveChanges();
entity.Name = "Joe";
await Verify(session);
```
<sup><a href='/src/Tests/Tests.cs#L49-L60' title='Snippet source file'>snippet source</a> | <a href='#snippet-Updated' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Will result in the following verified file:

<!-- snippet: Tests.Updated.verified.txt -->
<a id='snippet-Tests.Updated.verified.txt'></a>
```txt
[
  {
    Key: people/1-A,
    Changes: [
      {
        Type: FieldChanged,
        FieldName: Name,
        NewValue: Joe,
        OldValue: John
      }
    ]
  }
]
```
<sup><a href='/src/Tests/Tests.Updated.verified.txt#L1-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.Updated.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Raven](https://thenounproject.com/term/raven/2011311/) designed by [Maciej Świerczek](https://thenounproject.com/swierq/) from [The Noun Project](https://thenounproject.com).
