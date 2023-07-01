# Haruki



---

* Net 7
* Architecture Slice with CQRS
* Postgresql
* Mediatr
* Jwt
* Asp Identity
* SendInBlue
* Polly

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

## References

* https://medium.com/@ajidejibola/authentication-and-authorization-in-net-6-with-jwt-and-asp-net-identity-2566e75851fe
