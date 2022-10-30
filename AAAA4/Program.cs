using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                              });
});


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
app.UseSwagger();
app.UseSwagger();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
