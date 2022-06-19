using GestPharmaEF.WebApi.JWT_Authentication.JWTWebAuthentication.Repository;
using GestPharmaEF.WebApi.JWT_Authentication;
using GestPharmaEF.DAL;
using Microsoft.EntityFrameworkCore;
using GestPharmaEF.DAL.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using GestPharmaEF.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
	o=>{
		o.AddPolicy(name: "corsRoute", d =>
										  {
											  d.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
										  });
	});

builder.Services.AddScoped<IJWTManagerRepository, JWTManagerRepository>();
builder.Services.AddScoped<ArmoiresContenuRepository>();
builder.Services.AddScoped<ArmoireRepository>();
builder.Services.AddScoped<MedecinRepository>();
builder.Services.AddScoped<MedicamentRepository>();
builder.Services.AddScoped<MedicamentsPrescritRepository>();
builder.Services.AddScoped<OrdonnanceRepository>();
builder.Services.AddScoped<PersonneRepository>();
builder.Services.AddScoped<PharmacieRepository>();
builder.Services.AddScoped<RoleRepository>();

builder.Services.AddDbContext<BDPMContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("GestPharmaWorks")));

builder.Services.AddIdentity<PersonneEntity, RoleEntity>(
                options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 5;
                    options.Password.RequiredUniqueChars = 1;
                })
                .AddRoles<RoleEntity>()
                .AddEntityFrameworkStores<BDPMContext>()
                .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestPharma", Version = "v1" });

    OpenApiSecurityScheme securitySchema = new()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    };
    c.AddSecurityRequirement(securityRequirement);
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsRoute");

//app.UseAuthentication();
app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
