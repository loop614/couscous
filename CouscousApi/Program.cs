using CouscousApi.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using CouscousApi.Core;
using CouscousApi.Core.Domain;

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
builder.Services.AddHostedService<CouscousStartupService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.ApplyMigrations();
    app.UseDeveloperExceptionPage();
}
var couscousElasticClient = app.Services.GetService<CouscousElasticClient>();
if (couscousElasticClient is null) {
    Console.WriteLine("Sadly the elastic client could not construct");
    return;
}
int elasticResponse = await couscousElasticClient.InitElasticSearchAsync();
if (elasticResponse != 0)
{
    Console.WriteLine("Elastic could not init");
}

app.MapControllers();
app.UseCors(CouscousAllowSpecificOrigins);

app.Run();
