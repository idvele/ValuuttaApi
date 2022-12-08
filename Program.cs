var builder = WebApplication.CreateBuilder(args);

//tämä sallii kaiken liikenteen, muuta rajatuksi
//cors-settings
var myCorsPolicy = "MyCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(myCorsPolicy,
        builder =>
        {
            builder.AllowAnyOrigin()
            .WithExposedHeaders("x-my-custom-header");
        });
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors(myCorsPolicy);


app.Run();
