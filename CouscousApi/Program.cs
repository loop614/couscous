using CouscousApi.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using CouscousApi.Core;
using CouscousApi.Core.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<CouscousContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("CouscousContext"))
);

builder.Services.AddHostedService<CouscousStartupService>();

CouscousConfig.AddBuilderServices(builder);

var app = builder.Build();
app.MapControllers();
app.Run();
