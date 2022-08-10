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

Execute the command `bash simpleApp/start.sh tagname`. This will create a docker image and push it to remote repository. Make sure you change docker repository in `start.sh`and `deployment.yaml` with your own repo. Remember to change docker image in deployment file to match your tagname. To check if the application successfully deployed, go to `http://localhost:7141/index.html`. Alternatively, run the command `dotnet run -p simpleApp`
