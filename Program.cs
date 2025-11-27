var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable swagger in development & production
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
