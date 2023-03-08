using Microsoft.AspNetCore.Mvc;
using UpSwot_Test.BLL;

var builder = WebApplication.CreateBuilder(args);

const string UpSwotTestPolicy = "UpSwotTestPolicy";

builder.Services.AddControllers(options =>
{
    var cacheProfiles = builder.Configuration
        .GetSection("CacheProfiles")
        .GetChildren();

    foreach (var cacheProfile in cacheProfiles)
    {
        options.CacheProfiles
            .Add(cacheProfile.Key,
            cacheProfile.Get<CacheProfile>());
    }
});

builder.Services.AddCors(options => options.AddPolicy(UpSwotTestPolicy, builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithExposedHeaders("Token-Expired");
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddResponseCaching();

BLLModule.Load(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(UpSwotTestPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCaching();

app.Run();
