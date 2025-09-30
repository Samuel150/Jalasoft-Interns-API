using AutoMapper;
using Jalasoft.Interns.API.Adapter;
using Jalasoft.Interns.API.ExceptionHandling;
using Jalasoft.Interns.API.ExceptionHandling.Handlers;
using Jalasoft.Interns.Repository.Books;
using Jalasoft.Interns.Repository.Cities;
using Jalasoft.Interns.Repository.Employees;
using Jalasoft.Interns.Service.Books;
using Jalasoft.Interns.Service.Cities.Concretes;
using Jalasoft.Interns.Service.Cities.Interfaces;
using Jalasoft.Interns.Service.Employees;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using Jalasoft.Interns.Service.Validators.Employees;
using Jalasoft.Interns.Service.Validators.Cities;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Jalasoft.Interns.API.Adapters;
using Jalasoft.Interns.Service.Validators.Books;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureAutoMapper(builder.Services);
ConfigureIoC(builder.Services);
ConfigureResponseHandlers(builder.Services);

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

app.Run();


static void ConfigureIoC(IServiceCollection services)
{
    services.AddScoped<ResponseFilter>();

    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<EmployeeValidator>();

    services.AddScoped<IBookService, BookService>();
    services.AddSingleton<IBookRepository, BookRepository>();
    services.AddScoped<IBookAdapter, BookAdapter>();
    services.AddScoped<BookValidator>();
    services.AddScoped<AuthorValidator>();

    services.AddScoped<ICityService, CityService>();
    services.AddSingleton<ICityRepository, CityRepository>();
    services.AddScoped<ICityAdapter, CityAdapter>();
    services.AddScoped<CityValidator>();
    services.AddScoped<HospitalValidator>();

   
}

static void ConfigureResponseHandlers(IServiceCollection services)
{
    services.AddScoped<IErrorHandler, EmployeeNotFoundExceptionHandler>();
    services.AddScoped<IErrorHandler, CityNotFoundExceptionHandler>();
    services.AddScoped<IErrorHandler, JsonPatchExceptionHandler>();
}

static void ConfigureAutoMapper(IServiceCollection services)
{
    MapperConfiguration mapperConfig = new(c =>
    {
        c.AddMaps(Assembly.GetExecutingAssembly());
    }, new LoggerFactory());
    services.AddSingleton(mapperConfig.CreateMapper());
}
