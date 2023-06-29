# Haruki

NET 7 &amp; PostgreSQL

---

* Arquitecture Slice with CQRS
* Mediatr

## Migrations

~~~
* Apply
dotnet ef migrations add CreateInitialScheme -s Haruki.Api -o Persistences/Migrations
dotnet ef database update -s Haruki.Api
~~~

~~~
* Rollback
dotnet ef database update 0 -s Haruki.Api
dotnet ef migrations remove -s Haruki.Api
~~~
