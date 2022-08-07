var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerDocument(options =>
{
    options.DocumentName = "Example Api";
    options.Version = "V1";
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient("reddit", configureClient: client =>
{
    client.BaseAddress = new Uri("https://www.reddit.com/dev/api");
});
builder.Services.AddHttpClient(builder.Configuration["CatFactsClientName"], configureClient: client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CatFactsAddress"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseOpenApi();
app.UseSwaggerUi3();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
