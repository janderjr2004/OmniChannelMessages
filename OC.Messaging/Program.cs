using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using OC.Infra;
using OC.Libraries;
using OC.Application;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var sqlBuilder = new SqlConnectionStringBuilder(connectionString);
sqlBuilder.Encrypt = true;
sqlBuilder.TrustServerCertificate = true; 


builder.Services
    .AddDefaultInfra()
    .AddServices()
    .AddApplication()
    .AddDbContext<OCContext>(options =>
    options.UseSqlServer(sqlBuilder.ConnectionString));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
