## Description
- imports a [file](https://github.com/loop614/couscous/blob/main/CouscousApi/src/DataImport/Example/gamin_activity_metrics.json) made by Garmin Forerunner 255 smart watch
- exposes data to api

## Notes
- work in progress
- try graph databases !

## Requirements
- docker with compose
- dotnet 8
- Entity Framework Core .NET Command-line Tools 8.0.1

## Quick Start
- docker compose up couscous_postgres
- cd CouscousApi
- dotnet ef migrations add First && dotnet ef database update
- dotnet run
- [open](http://localhost:5184/activity/1)
