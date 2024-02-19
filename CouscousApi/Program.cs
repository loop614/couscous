using CouscousApi.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using CouscousApi.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<CouscousContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("CouscousContext"))
);

CouscousConfig.AddBuilderServices(builder);

var app = builder.Build();
app.MapControllers();
app.Run();
