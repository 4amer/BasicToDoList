using Microsoft.EntityFrameworkCore;
using ToDoListBackend.Data;
using ToDoListBackend.Repositories;
using ToDoListBackend.Repositories.Interfaces;
using ToDoListBackend.Services;
using ToDoListBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string allowOrigins = "origins";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoListService, ToDoListService>();

builder.Services.AddCors(option =>
{
    option.AddPolicy(name: allowOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
