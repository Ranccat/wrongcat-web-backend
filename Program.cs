var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Build app using the configutations set in builder
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
// }

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.Run();
