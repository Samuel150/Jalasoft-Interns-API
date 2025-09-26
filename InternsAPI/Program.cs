using Jalasoft.Interns.Repository.Employees;
using Jalasoft.Interns.Service.Employees;
using Jalasoft.Interns.Service.RepositoryInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
}
