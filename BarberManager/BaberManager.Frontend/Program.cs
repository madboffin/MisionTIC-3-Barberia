var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();  // 
builder.Services.AddHttpContextAccessor();

// To allow authentication
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    // options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.Name = ".BarberManager.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();// To allow authentication
app.MapRazorPages();
app.Run();
