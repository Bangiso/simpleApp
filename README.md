# Dotnet web api
A simple `dotnet=6.0` api with mysql db connection, exposing the following endpoints:

- `
  GET /students
  `

- `
  GET /students/{id}
  `
- `
    POST /students
    ` expecting the payload `{"id":1,"name":"Leo","gpa":70}`
- `
  PUT /students/{id}
  ` expecting the payload `{"id":1,"name":"Leo","gpa":70}`

- `
  DELETE /students/{id}
  `

# Database

Requires db setup that is outlined in `db-setup.sql` file. The credentials can be modified in the /Daos/StudentDao.cs file.

# Running the application

Run the command `dotnet run -p simpleApp`.  To check if the application successfully compiled,  go to `https://localhost:7141/index.html`.
