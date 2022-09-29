var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwaggerGen();
builder.Services.InjectDependencies();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtAuthentication(); 
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapUserEndpoints();
app.UseExceptionHandler();

CultureInfo cultureInfo = new CultureInfo("pt-BR");
cultureInfo.NumberFormat.CurrencySymbol = "$";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.Run();