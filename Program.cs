using ChatBot.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();


// «÷«›Â ò—œ‰ Authentication »« òÊò?
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Home/Index"; // ¬œ—” ’›ÕÂ ·«ê?‰ („?ù Ê‰?  €??— »œ?)
    options.LogoutPath = "/Home/Logout"; // «ê— ·«ê «Ê  Â„ œ«‘ Â »«‘?
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // “„«‰ «‰ﬁ÷«? òÊò?
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Œ?·? „Â„ ??
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<ChatHub>("/chatHub");
app.Run();
