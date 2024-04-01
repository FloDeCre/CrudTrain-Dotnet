using Microsoft.EntityFrameworkCore;
using UserDatabase;
using UserControllerName;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDb>(opt => opt.UseInMemoryDatabase("User"));
var app = builder.Build();

RouteGroupBuilder Users = app.MapGroup("/Users");

Users.MapGet("/", UserController.GetAllTodos);
Users.MapGet("/{id}", UserController.GetTodo);
Users.MapPost("/", UserController.CreateTodo);
Users.MapPut("/{id}", UserController.UpdateTodo);
Users.MapDelete("/{id}", UserController.DeleteTodo);


app.Run();
