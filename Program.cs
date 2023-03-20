using TicTacTo.Services;
using TicTacToe;
using TicTacToe.PostqreSQL;

var builder = WebApplication.CreateBuilder(args);

Startup.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

Entry.MigrateDB(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGrpcService<TicTacToeService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");




app.UseRouting();

app.MapControllers().RequireHost("*:5148");

app.MapGrpcService<TicTacToeService>().RequireHost("*:5107");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
