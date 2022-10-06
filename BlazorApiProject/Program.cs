/**
 * Title:            BlazorApiProject
 * class:			 Program.cs
 * Author:           Dominik Bregovic
 * Email:            dominik.bregovic@edu.fh-joanneum.at
 * Semester:         4
 * Last Change:      06.10.2022
 * Description:      This is our configuration-code. Here we define imports, layouts and error behavior
 */


using BlazorApiProject.Services.EmployeeServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<EmployeeService>();
builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5004/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
