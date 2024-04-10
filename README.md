# Test for .NET Back-end Development

Create a REST API to manage a car and motorcycle parking lot.



## Features 

Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.AspNetCore.Mvc.NewtonsoftJson
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
washbuckle.AspNetCore


## Steps 
First steps to start the installation to create the DB in SQL, execute the following commands

* in appsettings.json, please add your DB server

1 .- add-migration MigracionInicial2
2 .- Update-Database MigracionInicial2


Create a new vehicle:
To create the car the type id is the number 1
To create the motorcycle, the type id is number 2


### Authentication

In the class I have hardcoded the users who can access, in more occupied houses you can add the necessary ones, add the Role attribute to give access only to the Admin

/Constants/UserConstants

Recurso
POST /api/Autentication

https://localhost:7072/api/Autentication

Reuqest:
{
  "userName": "jgomez",
  "password": "admin123"
}

### Company

GET /api/companies
This method helps us to obtain the records registered in DB

POST /api/companies

{
  "id": 0,
  "name": "string",
  "address": "string",
  "telephone": "string",
  "numberMotorcycleSpaces": 0,
  "numberCarSpaces": 0
}

GET /api/companies/{id}

The id is sent in the path to filter by company

path: id


PUT /api/companies/{id}

path: id

Request:

{
  "id": 0,
  "name": "string",
  "address": "string",
  "telephone": "string",
  "numberMotorcycleSpaces": 0,
  "numberCarSpaces": 0
}

DELETE /api/companies/{id}

path: id

Request:

{
  "id": 0,
  "name": "string",
  "address": "string",
  "telephone": "string",
  "numberMotorcycleSpaces": 0,
  "numberCarSpaces": 0
}

### Vehicles

GET /api/Vehicles
This method helps us to obtain the records registered in DB


POST /api/Vehicles

{
  "id": 0,
  "brand": "string",
  "model": "string",
  "color": "string",
  "plate": "string",
  "type": 0,
  "isParking": true,
  "companyId": 0
}


GET /api/Vehicles/{id}

The id is sent in the path to filter by company

path: id

PUT /api/Vehicles/{id}

path: id

Request:
{
  "id": 0,
  "brand": "string",
  "model": "string",
  "color": "string",
  "plate": "string",
  "type": 0,
  "isParking": true,
  "companyId": 0
}

DELETE /api/Vehicles/{id}

path: id

Request:
{
  "id": 0,
  "brand": "string",
  "model": "string",
  "color": "string",
  "plate": "string",
  "type": 0,
  "isParking": true,
  "companyId": 0
}



