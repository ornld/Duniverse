# Duniverse Archives

An unofficial encyclopedia of Frank Herbert's Dune, live at
[duniverse.org](https://www.duniverse.org). One hundred eighty-three records,
two hundred forty-seven glossary terms, and every connection between them,
readable without spoilers.

The archive only shows what your reading has earned. Mark the last novel you
finished and the site seals everything past it: records, connections, prose,
even the wording of a relationship label waits for the book that reveals it.
Open the whole archive whenever you choose. The protection is a reading
companion, never a lock.

## The instruments

- **Archives**, search across every record by name, alias, or half-remembered fact
- **Timeline**, the Imperium in Guild reckoning, spaced by the years between events
- **Bloodlines**, the Atreides, Harkonnen, Corrino, and Kynes lines as one chart
- **Connections**, the shortest chain of relationships between any two records
- **Universe**, every record and edge drawn as one pannable constellation
- **Terminology**, a glossary in the voice of Herbert's own appendices
- **Sayings**, the chapter epigraphs of all six novels, shelved by book
- **The Mentat Trial**, a daily guess-the-record puzzle in five clues
- **The Siridar Register**, who holds each world, book by book

## How it is built

Blazor WebAssembly on .NET 10, published as a static site.

| Project | Role |
| --- | --- |
| `Duniverse.Core` | Models, seed data, and every service the site reasons with |
| `Duniverse.Web` | The site itself |
| `Duniverse.Prerender` | Writes a static shell per route so deep links land |
| `Duniverse.Tests` | The suite that holds the spoiler promises |
| `Duniverse` (root) | The original console encyclopedia the project grew from |

Canon lives in single reviewable files: `SpoilerTierMap` stamps each record's
book, `RelationshipMap` names each connection, `FiefMap` tracks each world's
holders, `BloodlineMap` places the family tree. A prose guard reads every
displayed sentence at startup and refuses to build the archive when safe text
names a sealed record. The same scan runs in the test suite, in the shipping
configuration, so a spoiler breach fails the deploy itself.

## Running it

```
dotnet run --project Duniverse.Web
```

```
dotnet test
```

Pushing to `main` runs the tests, publishes the site, prerenders the routes,
and deploys to GitHub Pages.

## Rights

All rights reserved. See [LICENSE](LICENSE) for the terms, the third-party
font and decoder notices, and what this project does not claim: Dune belongs
to Frank Herbert and his rights holders. This is fan work, unaffiliated with
Herbert Properties LLC.
