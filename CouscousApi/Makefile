migrate:
	dotnet ef database update --connection 'Host=localhost;Username=couscous;Password=couscous;Database=couscous'

nuke:
	rm -rf Migrations && dotnet ef database drop && dotnet ef migrations add First && dotnet ef database update
