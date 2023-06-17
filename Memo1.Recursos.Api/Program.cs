using System.Reflection;
using Memo1.Recursos.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // c.IncludeXmlComments(xmlPath);   
});
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddCoreServices();


builder.Services.AddCors(options =>
{
    options.AddPolicy("myCorsPolicy", policy =>
    {
        policy.WithOrigins("*")
            .WithHeaders("*")
            .WithMethods("*");
    });
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
}); 

app.UseHttpsRedirection();
app.UseCors("myCorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();