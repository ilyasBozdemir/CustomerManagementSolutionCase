# CustomerManagementSolutionCase
This GitHub repository provides a basic template for a simple CRUD (Create, Read, Update, Delete) application using .NET Core. The application has been developed in a layered structure, following Clean Architecture principles. It provides an API server to perform CRUD operations and includes a simple database model to manage customer data.


## CRUD Code Test 

Please read each note very carefully!
Feel free to add/change the project structure to a clean architecture to your view.
and if you are not able to work on the FrontEnd project, you can add a Swagger UI
in a new Front project.

Create a simple CRUD application with .NET that implements the below model:
```
Customer {
	FirstName
	LastName
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
### Practices and patterns (Must):

- [TDD](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2022)
- [DDD](https://en.wikipedia.org/wiki/Domain-driven_design)
- [BDD](https://en.wikipedia.org/wiki/Behavior-driven_development)
- [Clean architecture](https://github.com/jasontaylordev/CleanArchitecture)
- [CQRS](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_query_responsibility_separation) pattern ([Event sourcing](https://en.wikipedia.org/wiki/Domain-driven_design#Event_sourcing)).
- Clean git commits that show your work progress.

### Validations (Must)

- During Create; validate the phone number to be a valid *mobile* number only (Please use [Google LibPhoneNumber](https://github.com/google/libphonenumber) to validate number at the backend).

- A Valid email and a valid bank account number must be checked before submitting the form.

- Customers must be unique in the database: By `Firstname`, `Lastname`, and `DateOfBirth`.

- Email must be unique in the database.

### Storage (Must)

- Store the phone number in a database with minimized space storage (choose `varchar`/`string`, or `ulong` whichever store less space).

## Nice to do:
- Blazor Web.
- Docker-compose project that loads database service automatically which `docker-compose up`
