# Pasquale Plant

NET 7 &amp; PostgreSQL

---

* Arquitecture Slice with CQRS
* Mediatr

## Migrations

~~~
* Apply
dotnet ef migrations add CreateInitialScheme -s Pasquale.Plant.Api -o Persistences/Migrations
dotnet ef database update -s Pasquale.Plant.Api
~~~

~~~
* Rollback
dotnet ef database update 0 -s Pasquale.Plant.Api
dotnet ef migrations remove -s Pasquale.Plant.Api
~~~
