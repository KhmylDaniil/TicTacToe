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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
