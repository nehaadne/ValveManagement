using ValveManagement.Common.Context;
using Microsoft.Extensions.Logging.EventLog;
using ValveManagement.Repository.Interfaces;
using ValveManagement.Repository;

var builder = WebApplication.CreateBuilder(args);
// ConfigureLogging.
builder.Host.ConfigureLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder
        .AddDebug()
        .AddEventLog(new EventLogSettings()
        {
            SourceName = "ValveMangementLogSource",
            LogName = "ValveMangementErrorLog ",
            Filter = (x, y) => y >= LogLevel.Error
        });
});
// Add services to the container.
builder.Services.AddScoped<IYojanaRepository, YojanaRepository >();
builder.Services.AddScoped<ICommonDropDownRepo, CommonDropDownRepo>();
builder.Services.AddScoped<IvalveSegmentRepository,valveSegmentRepository>();
builder.Services.AddScoped<IValeConnectionRemarkRepo,ValeConnectionRemarkRepo>();
builder.Services.AddScoped<INetworkAsyncRepository, NetworkMasterAsyncRepository>();
builder.Services.AddScoped<IMasterDropdownRepository,MasterDropdownRepository>();
builder.Services.AddScoped<ISegmentAssignmentRepository, SegmentAssignmentRepository>();
builder.Services.AddScoped<ISegmentMasterRepository, SegmentMasterRepository>();
builder.Services.AddScoped<IValveConnDetailsRepo, ValveConnDetailsrepo>();
builder.Services.AddScoped<IValveconnectionRemarkphotoAsyncRepository, ValveconnectionRemarkphotoAsyncRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.SetIsOriginAllowed(_ => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

//// Configure  Services
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;


app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.

if (app.Environment.IsProduction() || app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "ValveMangement/swagger/{documentname}/swagger.json";
    });

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        // c.RoutePrefix = "ValveMangement/swagger";
        c.SwaggerEndpoint("/ValveMangement/swagger/v1/swagger.json", "master V1");
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
