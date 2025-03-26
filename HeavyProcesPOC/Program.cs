using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/heavy-process", () =>
{
    var sw = Stopwatch.StartNew();

    // Simulaci�n de carga con c�lculos aleatorios
    var rand = new Random();
    double result = 0;
    for (int i = 0; i < 10_000_000; i++)
    {
        double a = rand.NextDouble();
        double b = rand.NextDouble();
        result += Math.Sqrt(a * b) * Math.Sin(a + b);
    }

    sw.Stop();

    return Results.Ok(new
    {
        message = "Proceso con c�lculos completado",
        timeInMs = sw.ElapsedMilliseconds,
        sampleResult = result
    });
});

app.Run();
