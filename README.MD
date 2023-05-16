# ASP.NET Web API - CRUD

## About

This project is based on the Create, Read, Update and Delete (CRUD) processes to serve as an object of study for the development of an Application Programming Interface (API) using the `C#` programming language and the `ASP.NET Web API` library

### Why `C#`?

`C#` is a very performant programming language and is one of my favorites for developing simpler applications, even though the language has great potential to be used anywhere, in addition to its syntax, it makes me feel comfortable because it is very similar to `C++` that it is my main language, the large set of libraries make development much faster and scalable to the point of developing an API in just a few minutes.


#### Endpoints:

- v1/tasks - GET & POST
- v1/tasks/id - GET, PUT & DELETE


The endpoints that use the GET function return data in JSON format as in the example below:

```
{
    "id": 1,
    "title": "Task 1",
    "description": "Task 1 Description",
    "startDate": "2023-05-14T18:37:11.2182037",
    "endDate": "0001-01-01T00:00:00",
    "isFinished": false
}
```

using the POST & PUT method, you need to pass a JSON file as in the example below to create or update the data in the database
```
{
    "title": "new task",
    "description: "task description"
}
```

using the DELETE method, in this api is not necessary to pass any JSON file, just use the method followed by the data ID in the link

## Acquired knowledge
with this project it is possible to gain knowledge about the structures of an api using ASP.NET Web API, how the MVC design is structured and the HTTP methods, and how an entire api can be structured and scalable following good practices
