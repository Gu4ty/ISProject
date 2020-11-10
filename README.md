# Perfect Buy

This project is based on a buying and selling site that also allows auctions. It has a database where information on registered users is stored.

## Starting
To use the project, clone it or download it to your local computer.


### Requirements 📋
The implementation of the application was carried out on the Linux operating system,
using ASP.NET Core as a framework. To execute it you need:

- Install `.Net core` module.
- Install and configure `Apache` server.

You can find the steps to do this [here](https://www.c-sharpcorner.com/article/how-to-deploy-net-core-application-on-linux/)


### Mode of use

To run the migrations, you have to open a console from the root location of the project and execute:

```
dotnet ef migrations add AddTables
dotnet ef database drop
dotnet ef database update
```

To execute the project:

```
dotnet run
```

## Authors ✒️

* **Carmen Irene Cabrera Rodríguez** - [cicr99](https://github.com/cicr99)
* **Enrique Martínez González** - [kikeXD](https://github.com/kikeXD)
* **David Guaty Domínguez** - [Gu4ty](https://github.com/Gu4ty)

You can find the repository of the project in [github](https://github.com/Gu4ty/ISProject)