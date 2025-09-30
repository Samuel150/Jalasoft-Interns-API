using Jalasoft.Interns.Repository.Books;
using Jalasoft.Interns.Service.Books;

using Jalasoft.Interns.API.Adapter;
using Jalasoft.Interns.Repository.Cities;
using Jalasoft.Interns.Repository.Employees;
using Jalasoft.Interns.Service.Cities.Concretes;
using Jalasoft.Interns.Service.Cities.Interfaces;

using Jalasoft.Interns.Service.Employees;
using Jalasoft.Interns.Service.RepositoryInterfaces;
using Jalasoft.Interns.Service.Validators.Employees;
using Jalasoft.Interns.API.Adapters;
using Jalasoft.Interns.Service.Validators.Books;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureIoC(builder.Services);

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
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<IEmployeeAdapter, EmployeeAdapter>();
    services.AddScoped<EmployeeValidator>();

    services.AddScoped<IBookService, BookService>();
    services.AddSingleton<IBookRepository, BookRepository>();
    services.AddScoped<IBookAdapter, BookAdapter>();
    services.AddScoped<BookValidator>();

    services.AddScoped<ICityService, CityService>();
    services.AddSingleton<ICityRepository, CityRepository>();
    services.AddScoped<ICityAdapter, CityAdapter>();
}
