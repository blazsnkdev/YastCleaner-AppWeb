using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using YAST_CLENAER_WEB.Data;
using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Data.Repository;
using YAST_CLENAER_WEB.Data.UoW;
using YAST_CLENAER_WEB.Services.Impl;
using YAST_CLENAER_WEB.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//BD CONTEXT
builder.Services.AddDbContext<AppDbContext>
    (options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("cn1"));
    });

//UNIT OF WORK

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//REPOSITORIOS
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITipoServicioRepository,TipoServicioRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();



//SERVICIOS
builder.Services.AddScoped<ITipoServicioService, TipoServicioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();





//AUTENTICACIÓN, AUTORIZACIÓN Y ROLES AUTH0
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme; // <-- ESTA LÍNEA ES CLAVE
    })
    .AddCookie()
    .AddOpenIdConnect("Auth0", options =>
    {
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
        options.ClientId = builder.Configuration["Auth0:ClientId"]!;
        options.ClientSecret = builder.Configuration["Auth0:ClientSecret"]!;
        options.ResponseType = "code";
        options.CallbackPath = new PathString("/callback");
        options.SaveTokens = true;
        options.ClaimsIssuer = "Auth0";

        // Agregamos los scopes básicos
        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");

        // Mapeo para roles personalizados
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "name",
            RoleClaimType = "https://miapp.com/roles"
        };

        options.Events = new OpenIdConnectEvents
        {
            OnTokenValidated = context =>
            {
                var identity = (ClaimsIdentity)context.Principal.Identity!;
                var roleClaims = context.Principal.FindAll("https://miapp.com/roles").ToList();

                foreach (var role in roleClaims)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role.Value));
                }

                return Task.CompletedTask;
            }
        };



    });

builder.Services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Home/AccesoDenegado";      // si no ha iniciado sesión
    options.AccessDeniedPath = "/Home/AccesoDenegado"; // si inició sesión pero no tiene rol
});




builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


//MIGRACIONES A LA BASE DE DATOS
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


app.Run();
