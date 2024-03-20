using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//----------------------------------//
// Middleware
//----------------------------------//

// Custom Middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow} ] started");
    await next();
    Console.WriteLine("finished");
});

//----------------------------------//

var todos = new List<Todo>();

//----------------------------------//
// Routing 
//----------------------------------//

// get all todos
app.MapGet("/todos", () =>
{
    return todos;
});

// get request  
// returning the data in two different data types || Ok & NotFound
app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound> (int id) =>
{
    var targetTodo = todos.SingleOrDefault(t => t.Id == id);
    return targetTodo is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(targetTodo);
});

// post request to add item in list
app.MapPost("/todos", (Todo task1) =>
{
    todos.Add(task1);
    return TypedResults.Created("/todos/{id}", task1);
});

// delete todo from list
app.MapDelete("/todos/{id}", (int id) => { 
    todos.RemoveAll(t => t.Id == id);
    return TypedResults.NoContent();
});

//----------------------------------//

app.Run();

public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted) { }
