using Microsoft.OpenApi.Models;
using PizzaStore.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>{});

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API",Description="Making the pizzas you love!",Version="v1"});    
  });

var app = builder.Build();

app.UseCors("Middleware policy");


//Swagger
if(app.Environment.IsDevelopment()){ 

  app.UseSwagger();

  app.UseSwaggerUI(c=>{
    c.SwaggerEndpoint("/swagger/v1/swagger.json","PizzaStore API V1");
  });
}

app.MapGet("/", () => "Hello World from minimal api!");

//Pizza APIs
app.MapGet("/pizzas/{id}",(int id)=> PizzaDB.GetPizza(id));

app.MapGet("/pizzas",()=>PizzaDB.GetPizzas());

app.MapPost("/pizzas",(Pizza pizza)=>PizzaDB.CreatePizza(pizza));

app.MapPut("/pizzas",(Pizza pizza)=> PizzaDB.UpdatePizza(pizza));

app.MapDelete("/pizzas/{id}",(int id)=> PizzaDB.RemovePizza(id));

app.Run();
