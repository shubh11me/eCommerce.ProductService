using BuisnessLogicLayer;
using BuisnessLogicLayer.Mappers;
using BuisnessLogicLayer.Validations;
using DataAccessLayer;
using FluentValidation;
using FluentValidation.AspNetCore;
using ProductService.API.ApiEndpoints;
using ProductService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
//Add DAL layer services
builder.Services.AddDataAccessLayerServices(builder.Configuration);
builder.Services.AddBuisnessLogicLayerServices();

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

// Ensure minimal APIs use the same JSON options (e.g., enum as string)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(ProductAddRequestValidator));

//AutoMapper
builder.Services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);

//Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.Register();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
