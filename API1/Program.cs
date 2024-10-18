using PollyRecilencyPatterns.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient("api2", config =>
{
    config.BaseAddress = new Uri("https://localhost:5005");//dýþ servis entegrasyonu 
}).AddPolicyHandler(HttpRecilencyHelper.CreateRetryPolicy(retryCount:3,sleepDuration:TimeSpan.FromSeconds(2)));


//Mesaj kuyruk sistemi üzerinden haberleþme de protocol ve porta gerek yok ,
//dinamik olarak ip port deðiþiminden izoleyiz
//hata yönetimi ve recilency mass transitte 

var app = builder.Build();

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
