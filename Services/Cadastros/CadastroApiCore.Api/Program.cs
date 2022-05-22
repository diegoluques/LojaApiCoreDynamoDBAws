using CadastroApiCore.API.Pipeline;

var builder = WebApplication.CreateBuilder(args);

// Configure

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

NativeInjector.Configure(builder);

var app = builder.Build();

// ConfigureServices 

ExceptionHandlerConfiguration.UseGlobalExceptionHandler(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger((c) =>{
        c.SerializeAsV2 = true;
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

 