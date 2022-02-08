# SampleMunicornNotion

- To run application, execute `docker-compose up` command in `src` folder.

- Application will be available at localhost:5577/swagger

- pgAdmin will be available at port 8999, there you can inspect DB contents. If pgAdmin is not available, check permissions for `pgadmin-data` folder

- opening pgAdmin for first time, you need to add server (server name `postgres`, password `password`)

## Migrations

To add new migration, run 

```bash
dotnet-ef migrations add MigrationName -p SampleMunicornNotion.DAL -s SampleMunicornNotion.WebApi
```

Then add it to postgres-migrations folder, so that it could be applied automatically when postgres starts (only for new created database)

```bash
dotnet-ef migrations script -i -o postgres-migrations/migration.sql -p SampleMunicornNotion.DAL -s SampleMunicornNotion.WebApi
```
