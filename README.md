## Description
- imports a [file](https://github.com/loop614/couscous/blob/main/CouscousApi/src/DataImport/Example/gamin_activity_metrics.json) taken from Garmin Connect endpoint
- exposes data to api

## Notes
- work in progress

## Requirements
- docker with compose
- dotnet 8
- Entity Framework Core .NET Command-line Tools 8.0.1

## Quick Start
- docker compose up couscous_elasticsearch couscous_postgres
- cd CouscousApi
- dotnet run
- [endpoint1](http://localhost:5184/activity/1)
- [endpoint2](http://localhost:5184/events/elastic/activity/1)

## Kibana
- docker compose up couscous_elasticsearch couscous_kibana
- [console](http://localhost:5601/app/dev_tools#/console)

## Frontend
- cd couscousvue
- npm install
- npm run dev
- [open](http://localhost:5173/)
