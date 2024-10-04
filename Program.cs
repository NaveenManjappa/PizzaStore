using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>{});

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API",Description="Keep track of your tasks",Version="v1"});    
  });

var app = builder.Build();

app.UseCors("Middleware policy");




app.MapGet("/todo", () => "Hello World from minimal api!");


//Swagger
if(app.Environment.IsDevelopment()){ 

  app.UseSwagger();

  app.UseSwaggerUI(c=>{
    c.SwaggerEndpoint("/swagger/v1/swagger.json","To DO API V1");
  });
}
app.Run();
