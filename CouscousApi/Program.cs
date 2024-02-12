using CouscousApi.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using CouscousApi.DataImport;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<CouscousContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("CouscousContext"))
);

var app = builder.Build();
app.MapControllers();

new DataImportFacade().ImportExample();

app.Run();
