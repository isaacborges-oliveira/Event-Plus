
using System.Reflection;
using Eventplus_api_senai.Context;
using Eventplus_api_senai.Interfaces;
using Eventplus_api_senai.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services // Acessa a cole��o de servi�os da aplica��o (Dependency Injection)
.AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
.AddJsonOptions(options => // Configura as op��es do serializador JSON padr�o (System.Text.Json)
{
    // Configura��o para ignorar propriedades nulas ao serializar objetos em JSON
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

    // Configura��o para evitar refer�ncia circular ao serializar objetos que possuem relacionamentos recursivos
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});


// Adiciona o contexto do banco de dados (exemplo com SQL Server)fk
builder.Services.AddDbContext<Event_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar o reposit�rio e a interface ao continuar a inje��o de depend�ncia 
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPresencaRepository, PresencaRepository>();
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();

// Adicionar o servi�o de Controllers
builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";


})
   .AddJwtBearer("JwtBearer", options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {

           ValidateIssuer = true,


           ValidateAudience = true,


           ValidateLifetime = true,

           IssuerSigningKey = new SymmetricSecurityKey
           (System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),


           ClockSkew = TimeSpan.FromMinutes(5),


           ValidIssuer = "api_filmes_senai",

           ValidAudience = "api_filmes_senai"

       };
   });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Eventos",
        Description = "Aplicacao para gerenciamento de eventos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Isaac Borges Olivera",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autentica�ao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
// Adicionar o Mapeamento dos Controllers
app.UseCors("CorsPolicy");
app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
