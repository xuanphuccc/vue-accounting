using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Infrastructure;
using MySqlConnector;
using System.Globalization;
using MISA.WebFresher052023.Middleware;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Cấu hình validate input
        options.InvalidModelStateResponseFactory = (context) =>
        {
            var errors = context.ModelState.Values.SelectMany(error => error.Errors);
            var errorMsgs = string.Join(", ", errors.Select(error => error.ErrorMessage));

            return new BadRequestObjectResult(new BaseException()
            {
                ErrorCode = ErrorCode.BadRequest,
                UserMessage = ErrorMessage.BadRequest,
                DevMessage = errorMsgs,
                TraceId = context.HttpContext.TraceIdentifier,
                MoreInfo = "",
                Errors = context.ModelState
            });
        };
    })
    .AddJsonOptions(options =>
    {
        // Tắt bộ chuyển đổi PascalCase sang camelCase
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add repositories
var connectionString = builder.Configuration.GetConnectionString("MisaAccounting");

builder.Services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(connectionString));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();

// Add services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
builder.Services.AddScoped<IEmployeeExcelService, EmployeeExcelService>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();

builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IPositionManager, PositionManager>();

//Localization config
builder.Services.AddLocalization();
var localizationOptions = new RequestLocalizationOptions();
var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("vi-VN"),
};
localizationOptions.SupportedCultures = supportedCultures;
localizationOptions.SupportedUICultures = supportedCultures;
localizationOptions.SetDefaultCulture("en-US");
localizationOptions.ApplyCurrentCultureToResponseHeaders = true;


// Add Cors policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);
app.UseMiddleware<LocalizationMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
