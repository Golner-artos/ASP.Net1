var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const int SecretNumber = 7;
const string AccessKey = "letmein";

app.MapGet("/guess", (HttpRequest request, int? guess) =>
{
    if (!request.Headers.TryGetValue("X-Secret-Key", out var key) || key != AccessKey)
        return Results.Unauthorized();
    //Проверка guess и числа 
    if (guess == SecretNumber)
        return Results.Ok("Угадал");   //200 выведет

    return Results.BadRequest("Не угадал");  //400 выведет
});

//Если не будет передан ключ, то будет 404
app.Run();
