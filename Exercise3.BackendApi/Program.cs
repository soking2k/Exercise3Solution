using Exercise3.Application.Service;
using Exercise3.Data.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Exercise3Db");
builder.Services.AddDbContext<Exercise3DbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<iPublicAgreementService, PublicAgreementService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    /* options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://example.com",
                                "http://www.contoso.com");
        });*/

    options.AddPolicy("AnotherPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
            policy.WithOrigins("https://soking2k.github.io")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
            policy.WithOrigins("http://103.92.24.117")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwaggerUI();
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
app.UseCors();
app.UseAuthorization();
app.UseSwagger(x=> x.SerializeAsV2 = true);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
