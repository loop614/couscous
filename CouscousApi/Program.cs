using CouscousApi.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using CouscousApi.Core;
using CouscousApi.Core.Domain;
using CouscousApi.Core.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen();
var CouscousAllowSpecificOrigins = "_couscousAllowSpecificOrigins";

builder.Services.AddDbContext<CouscousContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("CouscousContext"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CouscousAllowSpecificOrigins, policy => { policy.WithOrigins("http://localhost:5173").AllowAnyMethod(); });
});

CouscousConfig.AddBuilderServices(builder);

var elasticSearchSettings = builder.Configuration.GetSection("Elastic").Get<ElasticSearchSettings>();
if (elasticSearchSettings is null)
{
    Console.WriteLine("Could not find elasticsearch settings");
    return;
}

int elasticInitResult = await CouscousConfig.InitElasticSearchAsync(elasticSearchSettings);
if (elasticInitResult == 0)
{
    Console.WriteLine("Could not init elastic search, make sure the service is running");
    return;
}

builder.Services.AddHostedService<CouscousStartupService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.ApplyMigrations();
    app.UseDeveloperExceptionPage();
}

app.MapControllers();
app.UseCors(CouscousAllowSpecificOrigins);

app.Run();
