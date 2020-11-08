# <img src="/src/icon.png" height="30px"> Verify.RavenDB

[![Build status](https://ci.appveyor.com/api/projects/status/3tbsai6lv4d005pg?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-ravendb)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.RavenDB.svg)](https://www.nuget.org/packages/Verify.RavenDB/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [RavenDB](https://ravendb.net/) bits.

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-verify?utm_source=nuget-verify&utm_medium=referral&utm_campaign=enterprise).

<a href='https://dotnetfoundation.org' alt='Part of the .NET Foundation'><img src='https://raw.githubusercontent.com/VerifyTests/Verify/master/docs/dotNetFoundation.svg' height='30px'></a><br>
Part of the <a href='https://dotnetfoundation.org' alt=''>.NET Foundation</a>

<!-- toc -->
## Contents

  * [Enable](#enable)
  * [Usage](#usage)
    * [Document added](#document-added)
    * [Document updated](#document-updated)
  * [Security contact information](#security-contact-information)<!-- endToc -->


## NuGet package

https://nuget.org/packages/Verify.RavenDB/


## Enable

Enable VerifyRavenDB once at assembly load time:

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
VerifyRavenDB.Enable();
```
<sup><a href='/src/Tests/Tests.cs#L15-L19' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Usage

Verifiying an [IDocumentSession](https://ravendb.net/docs/article-page/5.0/Csharp/client-api/session/what-is-a-session-and-how-does-it-work) will result in all pending changes being written to a snapshot.


### Document added

Adding a document to a session:

<!-- snippet: Added -->
<a id='snippet-added'></a>
```cs
var entity = new Person
{
    Name = "John"
};
session.Store(entity);
await Verifier.Verify(session);
```
<sup><a href='/src/Tests/Tests.cs#L42-L51' title='Snippet source file'>snippet source</a> | <a href='#snippet-added' title='Start of snippet'>anchor</a></sup>
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
<a id='snippet-updated'></a>
```cs
var entity = new Person
{
    Name = "John"
};
session.Store(entity);
session.SaveChanges();
entity.Name = "Joe";
await Verifier.Verify(session);
```
<sup><a href='/src/Tests/Tests.cs#L60-L71' title='Snippet source file'>snippet source</a> | <a href='#snippet-updated' title='Start of snippet'>anchor</a></sup>
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


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Raven](https://thenounproject.com/term/raven/2011311/) designed by [Maciej Świerczek](https://thenounproject.com/swierq/) from [The Noun Project](https://thenounproject.com/creativepriyanka).
