using CouscousApi.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using CouscousApi.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
var  CouscousAllowSpecificOrigins = "_couscousAllowSpecificOrigins";

builder.Services.AddDbContext<CouscousContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("CouscousContext"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CouscousAllowSpecificOrigins, policy => { policy.WithOrigins("http://localhost:5173").AllowAnyMethod() ;});
});
CouscousConfig.AddBuilderServices(builder);

var app = builder.Build();
app.MapControllers();
app.UseCors(CouscousAllowSpecificOrigins);
app.Run();
