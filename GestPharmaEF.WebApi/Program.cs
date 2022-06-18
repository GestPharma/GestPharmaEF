using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.JWT_Authentication;
using GestPharmaEF.DAL.Entities;
using GestPharmaEF.DAL;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BDPMContext>(
	
	o => 
		o.UseSqlServer(builder.Configuration.GetConnectionString("GestPharmaWorks"))
	);


builder.Services.AddIdentity<PersonneEntity, RoleEntity>(

	o =>
	{
		o.SignIn.RequireConfirmedAccount = false;
		o.Password.RequireDigit = true;
		o.Password.RequireLowercase = true;
		o.Password.RequireNonAlphanumeric = true;
		o.Password.RequireUppercase = true;
		o.Password.RequiredLength = 5;
		o.Password.RequiredUniqueChars = 1;
	})
	.AddEntityFrameworkStores<BDPMContext>();

builder.Services.AddCors(
	o=>{
		o.AddPolicy(name: "corsRoute", d =>
										  {
											  d.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
										  });
	});

builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	// var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
	byte[] macle = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRETJWT_GestPharmaEF", EnvironmentVariableTarget.Machine));
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,										// qui m'a donner le token
		ValidateAudience = true,									// pourquoi j'en ai besoin (domaine cad les API a joindre)
		ValidateLifetime = true,									// durée
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["JWT:Issuer"],			// Ici on va chercher Issuer et Audience dans l'appsetting de l'appli
		ValidAudience = builder.Configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(macle)			// pour une mutuelle validation entre client et serveur.
	};																// (Key) qui est dans l'appsetting et (macle) qui est en base de registre
});

builder.Services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();

 

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsRoute");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
