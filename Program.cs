using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ASP.NET.Core.Identity.Models.Contexts;
using ASP.NET.Core.Identity.Validators.Medico;
using ASP.NET.Core.Identity.ViewModels.Medico;
using ASP.NET.Core.Identity.Validators.Paciente;
using ASP.NET.Core.Identity.ViewModels.Paciente;
using ASP.NET.Core.Identity.Validators.Consulta;
using ASP.NET.Core.Identity.ViewModels.Consulta;
using ASP.NET.Core.Identity.Validators.MonitoramentoPaciente;
using ASP.NET.Core.Identity.ViewModels.MonitoramentoPaciente;
using Microsoft.AspNetCore.Identity;
using ASP.NET.Core.Identity.ViewModels.Usuario;
using ASP.NET.Core.Identity.Validators.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = false);

builder.Services.AddDbContext<SisMedContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireUppercase = false; //desativa obrigatoriedade de caracter maiusculo na senha
    options.Password.RequireNonAlphanumeric = false; //desativa obrigatoriedade de caracteres especiais na senha
    options.Password.RequiredLength = 3; //indica a quantidade de caracteres minimos na senha
    options.Password.RequireDigit = false; //desativa obrigatoriedade de caracteres numericos na senha
    // options.Stores.ProtectPersonalData = true; //criptografa dados pesoais
}).AddEntityFrameworkStores<SisMedContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login"; //rota padrão de autenticação
    options.AccessDeniedPath = "/Auth/Login"; //rota para quando não tem as credenciais necessarias
});

builder.Services.AddScoped<IValidator<AdicionarMedicoViewModel>, AdicionarMedicoValidator>();
builder.Services.AddScoped<IValidator<EditarMedicoViewModel>, EditarMedicoValidator>();
builder.Services.AddScoped<IValidator<AdicionarPacienteViewModel>, AdicionarPacienteValidator>();
builder.Services.AddScoped<IValidator<EditarPacienteViewModel>, EditarPacienteValidator>();
builder.Services.AddScoped<IValidator<AdicionarConsultaViewModel>, AdicionarConsultaValidator>();
builder.Services.AddScoped<IValidator<EditarConsultaViewModel>, EditarConsultaValidator>();
builder.Services.AddScoped<IValidator<AdicionarMonitoramentoViewModel>, AdicionarMonitoramentoPacienteValidator>();
builder.Services.AddScoped<IValidator<EditarMonitoramentoViewModel>, EditarMonitoramentoPacienteValidator>();
builder.Services.AddScoped<IValidator<AdicionarUsuarioViewModel>, AdicionarUsuarioValidator>();
builder.Services.AddScoped<IValidator<EditarUsuarioViewModel>, EditarUsuarioValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
