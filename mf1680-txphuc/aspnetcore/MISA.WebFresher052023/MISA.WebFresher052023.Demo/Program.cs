using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Demo;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Infrastructure;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = (context) =>
        {
            var errors = context.ModelState.Values.SelectMany(error => error.Errors);
            var errorMsgs = string.Join(", ", errors.Select(error => error.ErrorMessage));

            return new BadRequestObjectResult(new BaseException()
            {
                ErrorCode = 400,
                UserMessage = errorMsgs,
                DevMessage = errorMsgs,
                TraceId = context.HttpContext.TraceIdentifier,
                MoreInfo = "",
                Errors = errors
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

builder.Services.AddScoped<IEmployeeRepository>((option) => new EmployeeRepository(new MySqlConnection(connectionString)));

// Add services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
